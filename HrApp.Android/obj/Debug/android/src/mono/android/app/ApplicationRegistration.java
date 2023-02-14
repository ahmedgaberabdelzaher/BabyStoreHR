package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("HrApp.Droid.MainApplication, HrApp.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64552a7e8708233c29.MainApplication.class, crc64552a7e8708233c29.MainApplication.__md_methods);
		
	}
}
