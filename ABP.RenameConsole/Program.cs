using System;

namespace ABP.RenameConsole
{
    // translated from chinese
    class Program
    {
        private static bool isFirstRun = true;
        //Whether to create a backup
        private static bool _createBackup = true;
        //Project src directory
        private static string _folder = "";

        //Original project company name
        private static string _companyNamePlaceHolder = "";
        //Original project name
        private static string _projectNamePlaceHolder = "";
        //New project company name
        private static string _companyName = "";
        //New project name
        private static string _projectName = "";

        static void Main(string[] args)
        {
            if (!isFirstRun)
            {
                if (_folder == "")
                {
                    Console.WriteLine("Item address cannot be empty!, please re-enter!");
                    getParam();
                }
                if (_projectNamePlaceHolder == "" || _projectName == "")
                {
                    Console.WriteLine("The original project name and new project name cannot be empty, please re-enter");
                    getParam();
                }
            }
            else
            {
                getParam();
            }

            Console.WriteLine("Replacement...! Replacement completes automatic closing of the window");
            SolutionRenamer app = new SolutionRenamer(_folder, _companyNamePlaceHolder, _projectNamePlaceHolder, _companyName, _projectName);
            app.CreateBackup = _createBackup;//Whether to create a backup
            app.Run();
        }


        public static void getParam()
        {
            Console.WriteLine("Please enter the src root directory of the required ABP project:");
            _folder = Console.ReadLine();

            Console.WriteLine("Create a backup? (true creates backup; false does not create backup)");
             _createBackup = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Please enter the company name of the original project (if not, it can be empty):");
            _companyNamePlaceHolder = Console.ReadLine();
            Console.WriteLine("Please enter the project name of the original project:");
            _projectNamePlaceHolder = Console.ReadLine();

            Console.WriteLine("Please enter the company name of the new project (if it does not, it can be empty):");
            _companyName = Console.ReadLine();
            Console.WriteLine("Please enter the project name of the new project:");
            _projectName = Console.ReadLine();

            isFirstRun = false;
        }
    }
}
