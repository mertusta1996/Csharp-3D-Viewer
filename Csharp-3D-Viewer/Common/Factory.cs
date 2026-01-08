using Csharp3DViewer.Controller;
using Csharp3DViewer.Model;
using Csharp3DViewer.View;
using System.Windows.Forms;

namespace Csharp3DViewer.Common
{
    public class Factory
    {
        MainForm mainForm;
        MainControl mainControl;
        ModelData modelData;

        public void InitializeApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(CreateMainForm());
        }

        #region Create Form/Control/Model Methods

        public MainForm CreateMainForm()
        {
            if (mainForm == null)
            {
                mainForm = new MainForm();
                mainForm.SetControl(CreateMainControl());
            }
            return mainForm;
        }

        public MainControl CreateMainControl()
        {
            if (mainControl == null)
            {
                mainControl = new MainControl();
                mainControl.SetModel(CreateModelData());
            }
            return mainControl;
        }

        public ModelData CreateModelData()
        {
            if (modelData == null)
            {
                modelData = new ModelData();
            }
            return modelData;
        }

        #endregion

    }
}