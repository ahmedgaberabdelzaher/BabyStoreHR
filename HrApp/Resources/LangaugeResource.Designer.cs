﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HrApp.Resources {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LangaugeResource {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LangaugeResource() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("HrApp.Resources.LangaugeResource", typeof(LangaugeResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string IncomingExternal {
            get {
                return ResourceManager.GetString("IncomingExternal", resourceCulture);
            }
        }
        
        internal static string OutgoingExternal {
            get {
                return ResourceManager.GetString("OutgoingExternal", resourceCulture);
            }
        }
        
        internal static string Delayed {
            get {
                return ResourceManager.GetString("Delayed", resourceCulture);
            }
        }
        
        internal static string IncomingInternal {
            get {
                return ResourceManager.GetString("IncomingInternal", resourceCulture);
            }
        }
        
        internal static string Notifications {
            get {
                return ResourceManager.GetString("Notifications", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to please check your internet connection.
        /// </summary>
        internal static string NoInternet
        {
            get
            {
                return ResourceManager.GetString("NoInternet", resourceCulture);
            }
        }


        /// <summary>
        ///   Looks up a localized string similar to Server Error.
        /// </summary>
        internal static string ServerError
        {
            get
            {
                return ResourceManager.GetString("ServerError", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Poor internet connection or server is not responding.
        /// </summary>
        internal static string ServerErrorOrNoInternetConnection
        {
            get
            {
                return ResourceManager.GetString("ServerErrorOrNoInternetConnection", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Session Expired.
        /// </summary>
        internal static string SessionExpired
        {
            get
            {
                return ResourceManager.GetString("SessionExpired", resourceCulture);
            }
        }
    }
}