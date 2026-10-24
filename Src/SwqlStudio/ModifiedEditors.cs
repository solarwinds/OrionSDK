using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SwqlStudio.Autocomplete;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal class ModifiedEditors : Component
    {
        internal const string SwqlFileFilter = "SWQL Files (*.swql)|*.swql|All Files (*.*)|*.*";

        private readonly SaveFileDialog saveFileDialog;
        private QueryTab editorBeingClosedWithoutSaving;

        public Form Parent { get; set; }

        public ModifiedEditors()
        {
            saveFileDialog = new SaveFileDialog
            {
                Filter = SwqlFileFilter,
                DefaultExt = "swql"
            };
        }

        public bool SaveModifiedEditors(IEnumerable<QueryTab> queryTabs)
        {
            var modifiedEditors = queryTabs.Where(qe => qe.Modified)
                .ToList();
            foreach (var editor in modifiedEditors)
            {
                ActivateEditor(editor);
                var saveResult = AskToSaveResult(editor);
                if (saveResult == DialogResult.Cancel)
                    return false;

                if (saveResult == DialogResult.Yes)
                {
                    if (!DoSave(editor))
                        return false;
                }
                else
                    CloseEditorWithoutSaving(editor);
            }

            return true;
        }

        private DialogResult AskToSaveResult(QueryTab editor)
        {
            if (editor.Modified && Settings.Default.PromptToSaveOnClose)
            {
                var editorName = string.IsNullOrEmpty(editor.FileName)
                    ? editor.Parent?.Text
                    : Path.GetFileName(editor.FileName);
                editorName = string.IsNullOrWhiteSpace(editorName) ? "Query" : editorName.TrimEnd('*');
                var message = $"Do you want to save changes to '{editorName}'?";
                return MessageBox.Show(Parent, message, $"Save changes - {editorName}", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
            }

            return DialogResult.Yes;
        }

        public bool ConfirmCloseEditor(QueryTab editor)
        {
            if (!editor.Modified || ReferenceEquals(editorBeingClosedWithoutSaving, editor))
                return true;

            ActivateEditor(editor);
            var result = AskToSaveResult(editor);
            if (result == DialogResult.Yes)
                return DoSave(editor);

            return result == DialogResult.No;
        }

        private void ActivateEditor(QueryTab editor)
        {
            if (editor.Parent is Form dockContent)
            {
                dockContent.Activate();
                editor.Editor.Focus();
            }
        }

        private void CloseEditorWithoutSaving(QueryTab editor)
        {
            if (!(editor.Parent is Form dockContent))
                return;

            editorBeingClosedWithoutSaving = editor;
            try
            {
                dockContent.Close();
            }
            finally
            {
                editorBeingClosedWithoutSaving = null;
            }
        }

        public bool DoSave(QueryTab editor)
        {
            if (string.IsNullOrEmpty(editor.FileName))
                return DoSaveAs(editor);

            return SaveEditor(editor, editor.FileName);
        }

        public bool DoSaveAs(QueryTab editor)
        {
            saveFileDialog.FileName = string.IsNullOrEmpty(editor.FileName)
                ? GetSuggestedFileName(editor.QueryText)
                : editor.FileName;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return false;

            return SaveEditor(editor, saveFileDialog.FileName);
        }

        private static string GetSuggestedFileName(string queryText)
        {
            var timestamp = DateTime.Now;
            var entityName = QueryEntityNameParser.GetPrimaryEntityName(queryText);
            return QueryFileNamePattern.TryFormat(Settings.Default.QueryFileNamePattern, entityName, timestamp,
                out var fileName)
                ? fileName
                : QueryFileNamePattern.Format(QueryFileNamePattern.DefaultPattern, entityName, timestamp);
        }

        private bool SaveEditor(QueryTab editor, string fileName)
        {
            try
            {
                File.WriteAllText(fileName, editor.QueryText);
                editor.FileName = fileName;
                editor.MarkSaved();
                RecentFiles.Add(fileName);

                // The syntax highlighting strategy doesn't change
                // automatically, so do it manually.
                //editor.Document.HighlightingStrategy =
                //    HighlightingStrategyFactory.CreateHighlightingStrategyForFile(editor.FileName);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Parent, ex.Message, ex.GetType().Name);
                return false;
            }
        }
    }
}
