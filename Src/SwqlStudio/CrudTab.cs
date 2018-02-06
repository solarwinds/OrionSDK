using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    public partial class CrudTab : UserControl, IConnectionTab
    {
        private const int ControlsMargin = 3;
        private readonly CrudOperation _operation;

        private readonly Dictionary<Property, TextBox> _textboxes = new Dictionary<Property, TextBox>();
        private TextBox _uri;
        private Entity _entity;

        public CrudTab(CrudOperation operation)
        {
            _operation = operation;
            InitializeComponent();
        }

        public Entity Entity
        {
            get => _entity;
            set
            {
                _entity = value;
                CreateSubComponents();
            }
        }

        /// <inheritdoc />
        public IApplicationService ApplicationService { get; set; }

        /// <inheritdoc />
        public ConnectionInfo ConnectionInfo { get; set; }

        public event EventHandler CloseItself;

        private void CreateSubComponents()
        {
            _textboxes.Clear();
            container.Controls.Clear();
            container.SuspendLayout();
            try
            {
                var y = 0;

                bool createProperties = true;
                switch (_operation)
                {
                    case CrudOperation.Create:
                        break;
                    case CrudOperation.Delete:
                        createProperties = false;
                        goto case CrudOperation.Update;
                    case CrudOperation.Update:
                        _uri = CreateLabelAndTextbox("SwisUri", ref y);
                        y += ControlsMargin * 3;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                // for delete, uri is enough
                if (createProperties)
                {
                    foreach (var property in _entity.Properties)
                    {
                        var textBox = CreateLabelAndTextbox(property.Name, ref y);

                        _textboxes[property] = textBox;
                    }
                }

                var commit = new Button();
                container.Controls.Add(commit);

                commit.Text = _operation.ToString();
                commit.Top = y;
                commit.AutoSize = true;
                commit.Click += OnCommit;
            }
            finally
            {
                container.ResumeLayout();
            }
        }

        private void OnCommit(object sender, EventArgs e)
        {
            var propertyBag = CreatePropertyBag();

            try
            {
                var message = "";
                switch (_operation)
                {
                    case CrudOperation.Create:
                        var rv = ConnectionInfo.Proxy.Create(_entity.FullName, propertyBag);
                        message = $"Created: {rv}";
                        break;
                    case CrudOperation.Update:
                        ConnectionInfo.Proxy.Update(_uri.Text, propertyBag);
                        message = "OK";
                        break;
                    case CrudOperation.Delete:
                        ConnectionInfo.Proxy.Delete(_uri.Text);
                        message = "OK";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                MessageBox.Show(message, "SwqlStudio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnCloseItself();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to {_operation}: {ex.Message}",
                    "SwqlStudio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private PropertyBag CreatePropertyBag()
        {
            var rv = new PropertyBag();
            foreach (var property in _textboxes)
            {
                if (!string.IsNullOrEmpty(property.Value.Text))
                {
                    rv[property.Key.Name] = property.Value.Text;
                }
            }

            return rv;
        }


        private TextBox CreateLabelAndTextbox(string name, ref int y)
        {
            var label = new Label();
            container.Controls.Add(label);

            label.Text = name;
            label.AutoSize = true;
            label.Top = y;
            y += label.Height + ControlsMargin;

            var textBox = new TextBox();
            container.Controls.Add(textBox);
            textBox.Top = y;
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            textBox.Width = container.Width - ControlsMargin * 2;
            textBox.Left = ControlsMargin;
            y += textBox.Height + ControlsMargin;
            return textBox;
        }

        protected virtual void OnCloseItself()
        {
            CloseItself?.Invoke(this, EventArgs.Empty);
        }
    }
}