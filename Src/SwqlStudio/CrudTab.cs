using System;
using System.Linq;
using System.Windows.Forms;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    public partial class CrudTab : TabTemplate, IConnectionTab
    {
        private const string SwisUri = "SwisUri";

        private readonly CrudOperation _operation;

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
                BindProperties();
                CommitButton.Text = _operation.ToString();
            }
        }

        public event EventHandler CloseItself;

        private void BindProperties()
        {
            crudPropertyBindingSource.Clear();

            bool createProperties = true;
            switch (_operation)
            {
                case CrudOperation.Create:
                    break;
                case CrudOperation.Delete:
                    createProperties = false;
                    goto case CrudOperation.Update;
                case CrudOperation.Update:
                    crudPropertyBindingSource.Add(new CrudProperty(new Property
                    {
                        IsKey = true,
                        Name = SwisUri,
                        Type = typeof(string).Name
                    }, false));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // for delete, uri is enough
            if (createProperties)
            {
                foreach (var property in _entity.Properties
                    .OrderByDescending(p => p.IsKey)
                    .ThenBy(p => p.IsNavigable)
                    .ThenBy(p => p.IsInherited)
                    .ThenBy(p => p.Name))
                {
                    crudPropertyBindingSource.Add(new CrudProperty(property));
                }
            }
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            if (ConnectionInfo == null)
                return;

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
                        ConnectionInfo.Proxy.Update(((CrudProperty)crudPropertyBindingSource[0]).Value, propertyBag);
                        message = "OK";
                        break;
                    case CrudOperation.Delete:
                        ConnectionInfo.Proxy.Delete(((CrudProperty)crudPropertyBindingSource[0]).Value);
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
            foreach (CrudProperty property in crudPropertyBindingSource)
            {
                if (property.UseInPropertyBag && !string.IsNullOrEmpty(property.Value))
                {
                    rv[property.Name] = property.Value;
                }
            }

            return rv;
        }


        protected virtual void OnCloseItself()
        {
            CloseItself?.Invoke(this, EventArgs.Empty);
        }

        private void propertiesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int imageIndex = (int)propertiesDataGridView[e.ColumnIndex, e.RowIndex].Value;
                e.Value = propertiesImageList.Images[imageIndex];
            }
        }
    }
}