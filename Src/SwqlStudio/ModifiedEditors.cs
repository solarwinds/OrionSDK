using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal class ModifiedEditors : Component
    {
        private readonly SaveFileDialog saveFileDialog;

        public Form Parent { get; set; }

        public ModifiedEditors()
        {
            saveFileDialog = new SaveFileDialog();
        }

        public bool SaveModifiedEditors(IEnumerable<QueryTab> queryTabs)
        {
            var modifiedEditors = queryTabs.Where(qe => qe.Modified)
                .ToList();
            var needsSave = modifiedEditors.Any();
            DialogResult saveResult = AskToSaveResult(needsSave);

            if (saveResult == DialogResult.Yes)
            {
                foreach (var editor in modifiedEditors)
                {
                    if (!DoSave(editor))
                    {
                        return false;
                    }
                }
            }

            return saveResult != DialogResult.Cancel;
        }

        private DialogResult AskToSaveResult(bool needsSave)
        {
            if (needsSave && Settings.Default.PromptToSaveOnClose)
            {
                const string message = "There are unsaved changes in some editors. Do you want to save them?";
                return MessageBox.Show(Parent, message, "Save?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
            }

            return DialogResult.Yes;
        }

        public bool DoSave(QueryTab editor)
        {
            if (string.IsNullOrEmpty(editor.FileName))
                return DoSaveAs(editor);

            return SaveEditor(editor, editor.FileName);
        }

        public bool DoSaveAs(QueryTab editor)
        {
            saveFileDialog.FileName = editor.FileName;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return false;

            return SaveEditor(editor, saveFileDialog.FileName);
        }

        private bool SaveEditor(QueryTab editor, string fileName)
        {
            try
            {
                File.WriteAllText(fileName, editor.QueryText);
                editor.FileName = fileName;
                editor.MarkSaved();

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