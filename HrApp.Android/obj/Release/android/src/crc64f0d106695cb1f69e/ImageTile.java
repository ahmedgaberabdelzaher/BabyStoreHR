package crc64f0d106695cb1f69e;


public class ImageTile
	extends android.widget.ImageView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Syncfusion.SfPdfViewer.XForms.Droid.ImageTile, Syncfusion.SfPdfViewer.XForms.Android", ImageTile.class, __md_methods);
	}


	public ImageTile (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ImageTile.class) {
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.ImageTile, Syncfusion.SfPdfViewer.XForms.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public ImageTile (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ImageTile.class) {
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.ImageTile, Syncfusion.SfPdfViewer.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public ImageTile (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ImageTile.class) {
			mono.android.TypeManager.Activate ("Syncfusion.SfPdfViewer.XForms.Droid.ImageTile, Syncfusion.SfPdfViewer.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

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
