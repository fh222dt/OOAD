using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPirateRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            controller.Controller mainController = new controller.Controller();
            view.MainView mainView = new view.MainView();
            model.Registry mainModel = new model.Registry();

            mainModel.LoadFromFile();

            while (mainController.Start(mainView, mainModel )) ;

            //Save här???
            mainModel.SaveToFile();
        }
    }
}
