///// <summary>    
///// The assembly utilities.    
///// </summary>
//internal class AssemblyUtilities
//{        
//    #region Public Methods

//        public static void Copycontent()        
//        {            
//            var buildLocation = typeof(AssemblyUtilities).Assembly.CodeBase.Remove(0, 8).Replace((typeof(AssemblyUtilities).Assembly.ManifestModule).Name, string.Empty).Replace("/", @"\") + @"\Content";
            
//            var deployLocation = typeof(AssemblyUtilities).Assembly.Location.Replace((typeof(AssemblyUtilities).Assembly.ManifestModule).Name, string.Empty) + @"\Content";
            
//            Directory.CreateDirectory(deployLocation);

//            //Now Create all of the directories
//            foreach (string dirPath in Directory.GetDirectories(buildLocation, "*", SearchOption.AllDirectories))
//                Directory.CreateDirectory(dirPath.Replace(buildLocation, deployLocation));

//            //Copy all the files
//            foreach (string newPath in Directory.GetFiles(buildLocation, "*.*", SearchOption.AllDirectories))                
//                File.Copy(newPath, newPath.Replace(buildLocation, deployLocation), true);

//        }

//        /// <summary>
//        /// /// Use as first line in ad hoc tests (needed by XNA specifically)
//        /// </summary>
        
//    public static void SetEntryAssembly()
//    {        
//        SetEntryAssembly(typeof(AssemblyUtilities).Assembly);
//    }

//        /// <summary> 
//        /// Allows setting the Entry Assembly when needed. 
//        /// Use AssemblyUtilities.SetEntryAssembly() as first line in XNA ad hoc tests        
//        /// </summary>
        
//        /// <param name="assembly">
//        /// Assembly to set as entry assembly
//        /// </param>  
//        public static void SetEntryAssembly(Assembly assembly) 
//        {           
//            var manager = new AppDomainManager();
//            FieldInfo entryAssemblyfield = manager.GetType().GetField(
//                "m_entryAssembly", BindingFlags.Instance | BindingFlags.NonPublic); 
            
//            entryAssemblyfield.SetValue(manager, assembly);
            
//            AppDomain domain = AppDomain.CurrentDomain; 
            
//            FieldInfo domainManagerField = domain.GetType().GetField(
//                "_domainManager", BindingFlags.Instance | BindingFlags.NonPublic);          
            
//            domainManagerField.SetValue(domain, manager);        }

//        #endregion    }