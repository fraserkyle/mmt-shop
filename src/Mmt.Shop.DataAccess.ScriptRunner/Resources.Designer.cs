﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mmt.Shop.DataAccess.ScriptRunner {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Mmt.Shop.DataAccess.ScriptRunner.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF NOT EXISTS
        ///   (  SELECT [name]
        ///      FROM sys.tables
        ///      WHERE [name] = &apos;ChangeLog&apos;
        ///   )
        ///   CREATE TABLE ChangeLog 
        ///   (
        ///		ChangeLogVersion VARCHAR(50) NOT NULL CONSTRAINT PK_ChangeLog PRIMARY KEY CLUSTERED 
        ///   ).
        /// </summary>
        internal static string CreateChangeLog {
            get {
                return ResourceManager.GetString("CreateChangeLog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = &apos;{DBNAME}&apos;)
        ///  BEGIN
        ///    CREATE DATABASE {DBNAME}
        ///  END.
        /// </summary>
        internal static string CreateDatabaseCommand {
            get {
                return ResourceManager.GetString("CreateDatabaseCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT ChangeLogVersion FROM dbo.ChangeLog.
        /// </summary>
        internal static string GetExistingCommand {
            get {
                return ResourceManager.GetString("GetExistingCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT ChangeLog (ChangeLogVersion) VALUES (&apos;{ChangeVersion}&apos;).
        /// </summary>
        internal static string InsertChangeCommand {
            get {
                return ResourceManager.GetString("InsertChangeCommand", resourceCulture);
            }
        }
    }
}
