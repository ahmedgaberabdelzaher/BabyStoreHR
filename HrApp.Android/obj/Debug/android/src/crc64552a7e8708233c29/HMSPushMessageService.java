package crc64552a7e8708233c29;


public class HMSPushMessageService
	extends com.huawei.hms.push.HmsMessageService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNewToken:(Ljava/lang/String;Landroid/os/Bundle;)V:GetOnNewToken_Ljava_lang_String_Landroid_os_Bundle_Handler\n" +
			"n_onMessageReceived:(Lcom/huawei/hms/push/RemoteMessage;)V:GetOnMessageReceived_Lcom_huawei_hms_push_RemoteMessage_Handler\n" +
			"";
		mono.android.Runtime.register ("HrApp.Droid.HMSPushMessageService, HrApp.Android", HMSPushMessageService.class, __md_methods);
	}


	public HMSPushMessageService ()
	{
		super ();
		if (getClass () == HMSPushMessageService.class) {
			mono.android.TypeManager.Activate ("HrApp.Droid.HMSPushMessageService, HrApp.Android", "", this, new java.lang.Object[] {  });
		}
	}


	public void onNewToken (java.lang.String p0, android.os.Bundle p1)
	{
		n_onNewToken (p0, p1);
	}

	private native void n_onNewToken (java.lang.String p0, android.os.Bundle p1);


	public void onMessageReceived (com.huawei.hms.push.RemoteMessage p0)
	{
		n_onMessageReceived (p0);
	}

	private native void n_onMessageReceived (com.huawei.hms.push.RemoteMessage p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
