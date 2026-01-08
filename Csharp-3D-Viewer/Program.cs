using System;
using Csharp3DViewer.Common;

namespace Csharp3DViewer
{
    static class Program
    {
        /// <summary>
        /// The main input point of the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var factory = new Factory();
            factory.InitializeApplication();
        }
    }
}