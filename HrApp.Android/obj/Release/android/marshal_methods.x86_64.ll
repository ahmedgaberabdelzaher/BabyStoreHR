; ModuleID = 'obj/Release/android/marshal_methods.x86_64.ll'
source_filename = "obj/Release/android/marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [288 x i64] [
	i64 98382396393917666, ; 0: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 77
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 6
	i64 184249734353293910, ; 2: Unity.Container.dll => 0x28e96283e169256 => 118
	i64 232391251801502327, ; 3: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 120
	i64 347331204332682223, ; 4: ImageCircle.Forms.Plugin => 0x4d1f7e3dda87bef => 62
	i64 602466766465879987, ; 5: HrApp.Android => 0x85c6455042d4fb3 => 41
	i64 702024105029695270, ; 6: System.Drawing.Common => 0x9be17343c0e7726 => 1
	i64 720058930071658100, ; 7: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 25
	i64 761608270782653079, ; 8: Syncfusion.SfBusyIndicator.XForms.Android => 0xa91c6afe5ffe297 => 102
	i64 872800313462103108, ; 9: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 23
	i64 930393596299815015, ; 10: Syncfusion.SfRangeSlider.XForms.Android => 0xce96c0be0bfa867 => 109
	i64 994940342227176444, ; 11: Huawei.Hms.Push.dll => 0xdcebcf847280bfc => 59
	i64 996343623809489702, ; 12: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 129
	i64 1000557547492888992, ; 13: Mono.Security.dll => 0xde2b1c9cba651a0 => 39
	i64 1120440138749646132, ; 14: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 35
	i64 1252782872435405224, ; 15: Syncfusion.SfPdfViewer.XForms.Android => 0x1162c7628c34b1a8 => 104
	i64 1425944114962822056, ; 16: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 3
	i64 1491290866305144020, ; 17: Xamarin.Google.AutoValue.Annotations.dll => 0x14b2212446e714d4 => 131
	i64 1624659445732251991, ; 18: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 16
	i64 1731380447121279447, ; 19: Newtonsoft.Json => 0x18071957e9b889d7 => 81
	i64 1795316252682057001, ; 20: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 17
	i64 1797009951756623539, ; 21: AiForms.Effects.Droid.dll => 0x18f04307b84b9eb3 => 43
	i64 1836611346387731153, ; 22: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 120
	i64 1865037103900624886, ; 23: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 71
	i64 1981742497975770890, ; 24: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 28
	i64 1986553961460820075, ; 25: Xamarin.CommunityToolkit => 0x1b91a84d8004686b => 121
	i64 2040001226662520565, ; 26: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 40
	i64 2061151250911352171, ; 27: Huawei.Hms.Log => 0x1c9aae246aec556b => 55
	i64 2076847052340733488, ; 28: Syncfusion.Core.XForms => 0x1cd27163f7962630 => 98
	i64 2080779309381168229, ; 29: SVG.Forms.Plugin.Android => 0x1ce069c1e7a5ac65 => 95
	i64 2133195048986300728, ; 30: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 81
	i64 2254786158495914142, ; 31: Syncfusion.SfProgressBar.XForms.Android.dll => 0x1f4a9c10959dd89e => 106
	i64 2262844636196693701, ; 32: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 23
	i64 2284400282711631002, ; 33: System.Web.Services => 0x1fb3d1f42fd4249a => 37
	i64 2318169270833697477, ; 34: AiForms.Effects.Droid => 0x202bcaab6d44d2c5 => 43
	i64 2329709569556905518, ; 35: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 27
	i64 2335503487726329082, ; 36: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 114
	i64 2337758774805907496, ; 37: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 13
	i64 2469392061734276978, ; 38: Syncfusion.Core.XForms.Android.dll => 0x22450aff2ad74f72 => 97
	i64 2470498323731680442, ; 39: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 19
	i64 2547086958574651984, ; 40: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 119
	i64 2568489860015129477, ; 41: Huawei.Hms.Availableupdate.dll => 0x23a51beb53650385 => 51
	i64 2592350477072141967, ; 42: System.Xml.dll => 0x23f9e10627330e8f => 14
	i64 2612152650457191105, ; 43: Microsoft.IdentityModel.Tokens.dll => 0x24403afeed9892c1 => 80
	i64 2624866290265602282, ; 44: mscorlib.dll => 0x246d65fbde2db8ea => 7
	i64 2656907746661064104, ; 45: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 73
	i64 2692509909129159130, ; 46: Plugin.XamarinFormsSaveOpenPDFPackage => 0x255db77f2fdce1da => 88
	i64 2776255433543154418, ; 47: Huawei.Hmf.Tasks.dll => 0x26873d9b8a167af2 => 50
	i64 2783046991838674048, ; 48: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 13
	i64 2789714023057451704, ; 49: Microsoft.IdentityModel.JsonWebTokens.dll => 0x26b70e1f9943eab8 => 78
	i64 2960931600190307745, ; 50: Xamarin.Forms.Core => 0x2917579a49927da1 => 126
	i64 2973416776963745376, ; 51: XamForms.Controls.Calendar.dll => 0x2943b2ce081c6660 => 138
	i64 3017704767998173186, ; 52: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 35
	i64 3270330317141120886, ; 53: HrApp.Android.dll => 0x2d628c18b3631776 => 41
	i64 3289520064315143713, ; 54: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 26
	i64 3364695309916733813, ; 55: Xamarin.Firebase.Common => 0x2eb1cc8eb5028175 => 123
	i64 3402534845034375023, ; 56: System.IdentityModel.Tokens.Jwt.dll => 0x2f383b6a0629a76f => 112
	i64 3411255996856937470, ; 57: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 133
	i64 3522470458906976663, ; 58: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 31
	i64 3530710316062465247, ; 59: Plugin.Multilingual => 0x30ff9a5371b5dcdf => 86
	i64 3531994851595924923, ; 60: System.Numerics => 0x31042a9aade235bb => 12
	i64 3643493506442034919, ; 61: NGraphics.Android.Custom.dll => 0x32904a0a40eb7ee7 => 82
	i64 3667526520489045555, ; 62: Huawei.Agconnect.AgconnectCore.dll => 0x32e5abf06212ee33 => 46
	i64 3674854143856381852, ; 63: XamSvg.Abstractions.dll => 0x32ffb45fa5ee8f9c => 140
	i64 3727469159507183293, ; 64: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 30
	i64 3756217500168923014, ; 65: Syncfusion.SfBusyIndicator.XForms => 0x3420c3ea44aca786 => 103
	i64 3765676030881038928, ; 66: SVG.Forms.Plugin.Android.dll => 0x34425e660fde0250 => 95
	i64 3783726507060260521, ; 67: Microsoft.AspNetCore.SignalR.Common.dll => 0x34827f360c8e6ea9 => 69
	i64 3869221888984012293, ; 68: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 75
	i64 4055376381221176420, ; 69: Huawei.Hms.NetworkGrs.dll => 0x3847975519328464 => 57
	i64 4223289525753750523, ; 70: HrApp => 0x3a9c23729e2e23fb => 45
	i64 4247996603072512073, ; 71: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 134
	i64 4525561845656915374, ; 72: System.ServiceModel.Internals => 0x3ece06856b710dae => 38
	i64 4587490706011065879, ; 73: XamSvg.Droid => 0x3faa0a7dd6320e17 => 141
	i64 4636684751163556186, ; 74: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 33
	i64 4706792261117077996, ; 75: Prism.Unity.Forms => 0x4151e29fb370e9ec => 92
	i64 4794310189461587505, ; 76: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 119
	i64 4795410492532947900, ; 77: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 31
	i64 4877824738504089047, ; 78: Syncfusion.SfRangeSlider.Android => 0x43b183c17f261dd7 => 108
	i64 4930045999758365834, ; 79: XamSvg.Abstractions => 0x446b0ab75deed48a => 140
	i64 4998547060489277110, ; 80: Syncfusion.SfPdfViewer.XForms.dll => 0x455e68116d894eb6 => 105
	i64 5046316774542345679, ; 81: Huawei.Hms.Opendevice => 0x46081e5eb2b105cf => 58
	i64 5142919913060024034, ; 82: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 128
	i64 5203618020066742981, ; 83: Xamarin.Essentials => 0x4836f704f0e652c5 => 122
	i64 5375264076663995773, ; 84: Xamarin.Forms.PancakeView => 0x4a98c632c779bd7d => 127
	i64 5408338804355907810, ; 85: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 32
	i64 5507995362134886206, ; 86: System.Core.dll => 0x4c705499688c873e => 9
	i64 5679624767254653100, ; 87: Syncfusion.SfProgressBar.XForms => 0x4ed214a245b968ac => 107
	i64 5775268978821181986, ; 88: Syncfusion.SfBusyIndicator.Android => 0x5025e0899cf83222 => 101
	i64 5880868220621719076, ; 89: Huawei.Android.Hms.SecuritySsl.dll => 0x519d0a7d0d0a8624 => 49
	i64 5975932659239009399, ; 90: AiForms.Effects.dll => 0x52eec7177b98bc77 => 42
	i64 6014447449592687183, ; 91: Microsoft.AspNetCore.Http.Connections.Common.dll => 0x53779c16e939ea4f => 65
	i64 6034224070161570862, ; 92: Microsoft.AspNetCore.SignalR.Client.dll => 0x53bdded235179c2e => 68
	i64 6085203216496545422, ; 93: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 129
	i64 6086316965293125504, ; 94: FormsViewGroup.dll => 0x5476f10882baef80 => 44
	i64 6222399776351216807, ; 95: System.Text.Json.dll => 0x565a67a0ffe264a7 => 115
	i64 6227942033188892203, ; 96: Syncfusion.SfPdfViewer.XForms => 0x566e184839f2ae2b => 105
	i64 6300241346327543539, ; 97: Xamarin.Firebase.Iid => 0x576ef41fd714fef3 => 124
	i64 6401687960814735282, ; 98: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 27
	i64 6479910363780928313, ; 99: Huawei.Android.Hms.SecuritySsl => 0x59ed4424d188d339 => 49
	i64 6548213210057960872, ; 100: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 22
	i64 6560151584539558821, ; 101: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 76
	i64 6577563365557241066, ; 102: Syncfusion.SfRangeSlider.Android.dll => 0x5b48330813a984ea => 108
	i64 6591024623626361694, ; 103: System.Web.Services.dll => 0x5b7805f9751a1b5e => 37
	i64 6617685658146568858, ; 104: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 2
	i64 6659513131007730089, ; 105: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 25
	i64 6783125919820072783, ; 106: Microsoft.AspNetCore.Connections.Abstractions => 0x5e228115e59ec74f => 63
	i64 6876862101832370452, ; 107: System.Xml.Linq => 0x5f6f85a57d108914 => 15
	i64 7017588408768804231, ; 108: Microsoft.AspNetCore.SignalR.Protocols.Json => 0x61637b7a1c903587 => 70
	i64 7026608356547306326, ; 109: Syncfusion.Core.XForms.dll => 0x618387125bcb2356 => 98
	i64 7204980051946441770, ; 110: XamForms.Controls.Calendar => 0x63fd3b2f020b0c2a => 138
	i64 7216222056629072044, ; 111: HrApp.resources => 0x64252bba31b6f0ac => 0
	i64 7488575175965059935, ; 112: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 15
	i64 7496222613193209122, ; 113: System.IdentityModel.Tokens.Jwt => 0x6807eec000a1b522 => 112
	i64 7500049668289977301, ; 114: Unity.Abstractions.dll => 0x6815876fb435dbd5 => 117
	i64 7635363394907363464, ; 115: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 126
	i64 7637365915383206639, ; 116: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 122
	i64 7654504624184590948, ; 117: System.Net.Http => 0x6a3a4366801b8264 => 11
	i64 7735176074855944702, ; 118: Microsoft.CSharp => 0x6b58dda848e391fe => 5
	i64 7735352534559001595, ; 119: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 137
	i64 7756332380610150586, ; 120: Xamarin.Google.AutoValue.Annotations => 0x6ba407349220c0ba => 131
	i64 7784126582539947449, ; 121: Huawei.Hms.Base => 0x6c06c5e27ef80db9 => 52
	i64 7820441508502274321, ; 122: System.Data => 0x6c87ca1e14ff8111 => 36
	i64 7836164640616011524, ; 123: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 16
	i64 8083354569033831015, ; 124: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 26
	i64 8087206902342787202, ; 125: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 111
	i64 8138104942271396658, ; 126: HrApp.resources.dll => 0x70f05b53d4effb32 => 0
	i64 8167236081217502503, ; 127: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 4
	i64 8243855692487634729, ; 128: Microsoft.AspNetCore.SignalR.Protocols.Json.dll => 0x72680f13124eaf29 => 70
	i64 8375317123763839630, ; 129: Huawei.Hms.Device => 0x743b1a8cbb30a28e => 53
	i64 8428678171113854126, ; 130: Xamarin.Firebase.Iid.dll => 0x74f8ae23bb5494ae => 124
	i64 8465511506719290632, ; 131: Xamarin.Firebase.Messaging.dll => 0x757b89dcf7fc3508 => 125
	i64 8479135282796081847, ; 132: AiForms.Effects => 0x75abf09d858ab2b7 => 42
	i64 8518502242792458212, ; 133: Huawei.Hms.Device.dll => 0x7637cca8280347e4 => 53
	i64 8601935802264776013, ; 134: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 32
	i64 8626175481042262068, ; 135: Java.Interop => 0x77b654e585b55834 => 4
	i64 8638972117149407195, ; 136: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 5
	i64 8725526185868997716, ; 137: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 111
	i64 8822867224128132893, ; 138: Huawei.Android.Hms.SecurityEncrypt.dll => 0x7a711efeaa98171d => 48
	i64 8844506025403580595, ; 139: Plugin.FirebasePushNotification => 0x7abdff5eb1fb80b3 => 84
	i64 8853378295825400934, ; 140: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 136
	i64 8854686927553911847, ; 141: Plugin.SharedTransitions.dll => 0x7ae22ad8b2255c27 => 87
	i64 8902821854310209666, ; 142: XamSvg.XamForms.dll => 0x7b8d2d4eacbe9882 => 143
	i64 8963482838182047088, ; 143: Syncfusion.SfProgressBar.XForms.dll => 0x7c64b0269826ad70 => 107
	i64 9162065988803407493, ; 144: XamForms.Controls.Calendar.Droid.dll => 0x7f2632795f50ae85 => 139
	i64 9244338242424394172, ; 145: Huawei.Hms.NetworkGrs => 0x804a7ca72343d1bc => 57
	i64 9289084858135747932, ; 146: NGraphics.Android.Custom => 0x80e9757679a41d5c => 82
	i64 9324707631942237306, ; 147: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 17
	i64 9427266486299436557, ; 148: Microsoft.IdentityModel.Logging.dll => 0x82d460ebe6d2a60d => 79
	i64 9501029730072421347, ; 149: Huawei.Hms.Push => 0x83da70336d6463e3 => 59
	i64 9646958908362757981, ; 150: Plugin.Multilingual.Abstractions.dll => 0x85e0e203efc0975d => 85
	i64 9662334977499516867, ; 151: System.Numerics.dll => 0x8617827802b0cfc3 => 12
	i64 9678050649315576968, ; 152: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 19
	i64 9704315356731487263, ; 153: Plugin.FirebasePushNotification.dll => 0x86aca766ba59341f => 84
	i64 9808709177481450983, ; 154: Mono.Android.dll => 0x881f890734e555e7 => 6
	i64 9850445980673189563, ; 155: HrApp.dll => 0x88b3d06df53326bb => 45
	i64 9998632235833408227, ; 156: Mono.Security => 0x8ac2470b209ebae3 => 39
	i64 10038780035334861115, ; 157: System.Net.Http.dll => 0x8b50e941206af13b => 11
	i64 10200434532125394699, ; 158: Huawei.Hmf.Tasks => 0x8d8f3929a9f6470b => 50
	i64 10219142040998308282, ; 159: Huawei.Hms.Base.dll => 0x8dd1af8afef6e9ba => 52
	i64 10229024438826829339, ; 160: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 22
	i64 10321854143672141184, ; 161: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 135
	i64 10430153318873392755, ; 162: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 20
	i64 10447083246144586668, ; 163: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 71
	i64 10810727582997339763, ; 164: Huawei.Hms.Availableupdate => 0x96076b758412de73 => 51
	i64 10895408586901726048, ; 165: Prism.Unity.Forms.dll => 0x973444622904a360 => 92
	i64 11002576679268595294, ; 166: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 74
	i64 11023048688141570732, ; 167: System.Core => 0x98f9bc61168392ac => 9
	i64 11037814507248023548, ; 168: System.Xml => 0x992e31d0412bf7fc => 14
	i64 11050168729868392624, ; 169: Microsoft.AspNetCore.Http.Features => 0x995a15e9dbef58b0 => 66
	i64 11122995063473561350, ; 170: Xamarin.CommunityToolkit.dll => 0x9a5cd113fcc3df06 => 121
	i64 11162124722117608902, ; 171: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 34
	i64 11221835998582316105, ; 172: Huawei.Hms.Ui => 0x9bbbf86287309c49 => 61
	i64 11226290749488709958, ; 173: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 76
	i64 11237162742616054720, ; 174: Polly => 0x9bf26bfa34e25bc0 => 89
	i64 11340910727871153756, ; 175: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 21
	i64 11345533118204769135, ; 176: XamForms.Controls.Calendar.Droid => 0x9d736e428206736f => 139
	i64 11356770688168724568, ; 177: SVG.Forms.Plugin.Abstractions => 0x9d9b5ac527dd8858 => 94
	i64 11474967336136963068, ; 178: Huawei.Hms.Hatool => 0x9f3f45fec7a773fc => 54
	i64 11513602507638267977, ; 179: System.IO.Pipelines.dll => 0x9fc8887aa0d36049 => 113
	i64 11529969570048099689, ; 180: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 34
	i64 11530571088791430846, ; 181: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 75
	i64 11574338195132234057, ; 182: Syncfusion.SfRangeSlider.XForms.Android.dll => 0xa0a04f43d717b949 => 109
	i64 11758626982801240232, ; 183: Syncfusion.SfBusyIndicator.XForms.Android.dll => 0xa32f08f0e430f0a8 => 102
	i64 11986148774707385255, ; 184: XamSvg.Shared.dll => 0xa6575ace256ad3a7 => 142
	i64 12102847907131387746, ; 185: System.Buffers => 0xa7f5f40c43256f62 => 8
	i64 12145679461940342714, ; 186: System.Text.Json => 0xa88e1f1ebcb62fba => 115
	i64 12212747205940921632, ; 187: Syncfusion.SfProgressBar.XForms.Android => 0xa97c64e0bdc0c520 => 106
	i64 12313367145828839434, ; 188: System.IO.Pipelines => 0xaae1de2e1c17f00a => 113
	i64 12361596062003817520, ; 189: Plugin.Multilingual.dll => 0xab8d361fb49aec30 => 86
	i64 12439275739440478309, ; 190: Microsoft.IdentityModel.JsonWebTokens => 0xaca12f61007bf865 => 78
	i64 12451044538927396471, ; 191: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 24
	i64 12466513435562512481, ; 192: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 29
	i64 12538491095302438457, ; 193: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 18
	i64 12711617764981604187, ; 194: Huawei.Android.Hms.SecurityEncrypt => 0xb068bd021a45ff5b => 48
	i64 12832250852553794196, ; 195: Syncfusion.SfBusyIndicator.XForms.dll => 0xb2155029872c2294 => 103
	i64 12843321153144804894, ; 196: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 77
	i64 12876461035432930612, ; 197: Huawei.Hms.Hatool.dll => 0xb2b26116dd236d34 => 54
	i64 12953969983053113793, ; 198: Prism.Forms => 0xb3c5bf1106f429c1 => 91
	i64 12963446364377008305, ; 199: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 1
	i64 13196197655982686080, ; 200: Prism => 0xb7224fda06b0bf80 => 90
	i64 13280903765250193763, ; 201: Unity.Abstractions => 0xb84f3f9bf7e2b963 => 117
	i64 13295219713260136977, ; 202: Microsoft.AspNetCore.Http.Connections.Client => 0xb8821be35ba42a11 => 64
	i64 13297997883559027856, ; 203: Syncfusion.Compression.Portable => 0xb88bfa9e896ea490 => 96
	i64 13370592475155966277, ; 204: System.Runtime.Serialization => 0xb98de304062ea945 => 3
	i64 13428779960367410341, ; 205: Microsoft.AspNetCore.SignalR.Client.Core.dll => 0xba5c9c39a8956ca5 => 67
	i64 13454009404024712428, ; 206: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 132
	i64 13465488254036897740, ; 207: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 137
	i64 13572454107664307259, ; 208: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 30
	i64 13622732128915678507, ; 209: Syncfusion.Core.XForms.Android => 0xbd0daab1e651e52b => 97
	i64 13647894001087880694, ; 210: System.Data.dll => 0xbd670f48cb071df6 => 36
	i64 13828521679616088467, ; 211: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 136
	i64 13842256465236365716, ; 212: Syncfusion.SfRangeSlider.XForms => 0xc01992ea6c449194 => 110
	i64 13852575513600495870, ; 213: ImageCircle.Forms.Plugin.dll => 0xc03e3c09186e90fe => 62
	i64 13901627684715465194, ; 214: SVG.Forms.Plugin.Abstractions.dll => 0xc0ec80b9ab3389ea => 94
	i64 13959074834287824816, ; 215: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 24
	i64 13967638549803255703, ; 216: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 128
	i64 13970307180132182141, ; 217: Syncfusion.Licensing => 0xc1e0805ccade287d => 99
	i64 14124974489674258913, ; 218: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 18
	i64 14438260825521943376, ; 219: RestSharp.dll => 0xc85f01b93fac7350 => 93
	i64 14538127318538747197, ; 220: Syncfusion.Licensing.dll => 0xc9c1cdc518e77d3d => 99
	i64 14551742072151931844, ; 221: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 114
	i64 14604329626201521481, ; 222: Microsoft.AspNetCore.SignalR.Client => 0xcaad006b00747d49 => 68
	i64 14669215534098758659, ; 223: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 73
	i64 14748851336349168659, ; 224: Syncfusion.Pdf.Portable.dll => 0xccae7225cc233413 => 100
	i64 14789919016435397935, ; 225: Xamarin.Firebase.Common.dll => 0xcd4058fc2f6d352f => 123
	i64 14792063746108907174, ; 226: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 132
	i64 14809184851036126845, ; 227: Microsoft.AspNetCore.SignalR.Client.Core => 0xcd84cb28db1abe7d => 67
	i64 14852515768018889994, ; 228: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 21
	i64 14890749653179496492, ; 229: Huawei.Hms.Log.dll => 0xcea691ea3d08f82c => 55
	i64 14935719434541007538, ; 230: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 2
	i64 14954917835170835695, ; 231: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 72
	i64 14970123681643361337, ; 232: Plugin.Multilingual.Abstractions => 0xcfc0902c6003f439 => 85
	i64 15066237768853720495, ; 233: Huawei.Hms.NetworkCommon => 0xd116076d2a198daf => 56
	i64 15088973192230695711, ; 234: NGraphics.Custom.dll => 0xd166cd2c6c4d731f => 83
	i64 15216786773475677495, ; 235: Plugin.XamarinFormsSaveOpenPDFPackage.dll => 0xd32ce2f2cfe15537 => 88
	i64 15370334346939861994, ; 236: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 20
	i64 15377983283090003614, ; 237: Syncfusion.SfBusyIndicator.Android.dll => 0xd5699251e679969e => 101
	i64 15391712275433856905, ; 238: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 72
	i64 15440341663105042387, ; 239: XamSvg.XamForms => 0xd6471cefa80a47d3 => 143
	i64 15460377942336190536, ; 240: Huawei.Android.Hms.SecurityBase.dll => 0xd68e4bd3723bb848 => 47
	i64 15609085926864131306, ; 241: System.dll => 0xd89e9cf3334914ea => 10
	i64 15663313122684323054, ; 242: NGraphics.Custom => 0xd95f444c1b5044ee => 83
	i64 15810740023422282496, ; 243: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 130
	i64 15847085070278954535, ; 244: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 116
	i64 15852824340364052161, ; 245: Microsoft.AspNetCore.Http.Features.dll => 0xdc008bbee610c6c1 => 66
	i64 15897019536993143047, ; 246: XamSvg.Droid.dll => 0xdc9d8f0af9ebc907 => 141
	i64 15930129725311349754, ; 247: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 134
	i64 15963349826457351533, ; 248: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 40
	i64 15992843576024808175, ; 249: Huawei.Hms.Ui.dll => 0xddf1fe7fa958baef => 61
	i64 16010501072521946958, ; 250: Huawei.Hms.NetworkCommon.dll => 0xde30b9e5efae674e => 56
	i64 16035518054986892682, ; 251: Prism.dll => 0xde899ab610db458a => 90
	i64 16154507427712707110, ; 252: System => 0xe03056ea4e39aa26 => 10
	i64 16156430004425724367, ; 253: Microsoft.AspNetCore.Http.Connections.Client.dll => 0xe0372b7d144211cf => 64
	i64 16321164108206115771, ; 254: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 74
	i64 16358326039458771190, ; 255: Huawei.Hms.Stats.dll => 0xe30472dcddf670f6 => 60
	i64 16505967687213018679, ; 256: Huawei.Hms.Stats => 0xe510fa28be686e37 => 60
	i64 16527749710595459278, ; 257: Syncfusion.Compression.Portable.dll => 0xe55e5ccb449b88ce => 96
	i64 16605226748660468415, ; 258: Microsoft.AspNetCore.SignalR.Common => 0xe6719dbfe8b8cabf => 69
	i64 16608271216877230369, ; 259: Unity.Container => 0xe67c6ead674fd921 => 118
	i64 16700268707773170941, ; 260: Syncfusion.SfPdfViewer.XForms.Android.dll => 0xe7c345e86c6444fd => 104
	i64 16833383113903931215, ; 261: mscorlib => 0xe99c30c1484d7f4f => 7
	i64 16904434304620314439, ; 262: Huawei.Agconnect.AgconnectCore => 0xea989d6fbfd23f47 => 46
	i64 16955506688107500054, ; 263: Syncfusion.Pdf.Portable => 0xeb4e0f7fab685216 => 100
	i64 17118171214553292978, ; 264: System.Threading.Channels => 0xed8ff6060fc420b2 => 116
	i64 17137864900836977098, ; 265: Microsoft.IdentityModel.Tokens => 0xedd5ed53b705e9ca => 80
	i64 17151170952569239713, ; 266: RestSharp => 0xee05331c4de338a1 => 93
	i64 17158783226145295961, ; 267: Plugin.SharedTransitions => 0xee203e6edc524e59 => 87
	i64 17337559581350925250, ; 268: Syncfusion.SfRangeSlider.XForms.dll => 0xf09b6294b69793c2 => 110
	i64 17571845317586269034, ; 269: Microsoft.AspNetCore.Connections.Abstractions.dll => 0xf3dbbc377ad7336a => 63
	i64 17609290784187047109, ; 270: Huawei.Android.Hms.SecurityBase => 0xf460c4ab92075cc5 => 47
	i64 17636563193350668017, ; 271: Microsoft.AspNetCore.Http.Connections.Common => 0xf4c1a8c826653ef1 => 65
	i64 17675249797910273188, ; 272: Polly.dll => 0xf54b1a0b30bc9ca4 => 89
	i64 17704177640604968747, ; 273: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 29
	i64 17710060891934109755, ; 274: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 28
	i64 17790600151040787804, ; 275: Microsoft.IdentityModel.Logging => 0xf6e4e89427cc055c => 79
	i64 17827832363535584534, ; 276: Xamarin.Forms.PancakeView.dll => 0xf7692f1427c04d16 => 127
	i64 17838668724098252521, ; 277: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 8
	i64 17882897186074144999, ; 278: FormsViewGroup => 0xf82cd03e3ac830e7 => 44
	i64 17891337867145587222, ; 279: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 135
	i64 17892495832318972303, ; 280: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 130
	i64 17957010574918374872, ; 281: XamSvg.Shared => 0xf9341dfa41f155d8 => 142
	i64 17986907704309214542, ; 282: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 133
	i64 18121944136070456290, ; 283: Huawei.Hms.Opendevice.dll => 0xfb7e142d75f3e3e2 => 58
	i64 18129453464017766560, ; 284: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 38
	i64 18337470502355292274, ; 285: Xamarin.Firebase.Messaging => 0xfe7bc8440c175072 => 125
	i64 18380184030268848184, ; 286: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 33
	i64 18434045720645380019 ; 287: Prism.Forms.dll => 0xffd2e2ea4860a7b3 => 91
], align 16
@assembly_image_cache_indices = local_unnamed_addr constant [288 x i32] [
	i32 77, i32 6, i32 118, i32 120, i32 62, i32 41, i32 1, i32 25, ; 0..7
	i32 102, i32 23, i32 109, i32 59, i32 129, i32 39, i32 35, i32 104, ; 8..15
	i32 3, i32 131, i32 16, i32 81, i32 17, i32 43, i32 120, i32 71, ; 16..23
	i32 28, i32 121, i32 40, i32 55, i32 98, i32 95, i32 81, i32 106, ; 24..31
	i32 23, i32 37, i32 43, i32 27, i32 114, i32 13, i32 97, i32 19, ; 32..39
	i32 119, i32 51, i32 14, i32 80, i32 7, i32 73, i32 88, i32 50, ; 40..47
	i32 13, i32 78, i32 126, i32 138, i32 35, i32 41, i32 26, i32 123, ; 48..55
	i32 112, i32 133, i32 31, i32 86, i32 12, i32 82, i32 46, i32 140, ; 56..63
	i32 30, i32 103, i32 95, i32 69, i32 75, i32 57, i32 45, i32 134, ; 64..71
	i32 38, i32 141, i32 33, i32 92, i32 119, i32 31, i32 108, i32 140, ; 72..79
	i32 105, i32 58, i32 128, i32 122, i32 127, i32 32, i32 9, i32 107, ; 80..87
	i32 101, i32 49, i32 42, i32 65, i32 68, i32 129, i32 44, i32 115, ; 88..95
	i32 105, i32 124, i32 27, i32 49, i32 22, i32 76, i32 108, i32 37, ; 96..103
	i32 2, i32 25, i32 63, i32 15, i32 70, i32 98, i32 138, i32 0, ; 104..111
	i32 15, i32 112, i32 117, i32 126, i32 122, i32 11, i32 5, i32 137, ; 112..119
	i32 131, i32 52, i32 36, i32 16, i32 26, i32 111, i32 0, i32 4, ; 120..127
	i32 70, i32 53, i32 124, i32 125, i32 42, i32 53, i32 32, i32 4, ; 128..135
	i32 5, i32 111, i32 48, i32 84, i32 136, i32 87, i32 143, i32 107, ; 136..143
	i32 139, i32 57, i32 82, i32 17, i32 79, i32 59, i32 85, i32 12, ; 144..151
	i32 19, i32 84, i32 6, i32 45, i32 39, i32 11, i32 50, i32 52, ; 152..159
	i32 22, i32 135, i32 20, i32 71, i32 51, i32 92, i32 74, i32 9, ; 160..167
	i32 14, i32 66, i32 121, i32 34, i32 61, i32 76, i32 89, i32 21, ; 168..175
	i32 139, i32 94, i32 54, i32 113, i32 34, i32 75, i32 109, i32 102, ; 176..183
	i32 142, i32 8, i32 115, i32 106, i32 113, i32 86, i32 78, i32 24, ; 184..191
	i32 29, i32 18, i32 48, i32 103, i32 77, i32 54, i32 91, i32 1, ; 192..199
	i32 90, i32 117, i32 64, i32 96, i32 3, i32 67, i32 132, i32 137, ; 200..207
	i32 30, i32 97, i32 36, i32 136, i32 110, i32 62, i32 94, i32 24, ; 208..215
	i32 128, i32 99, i32 18, i32 93, i32 99, i32 114, i32 68, i32 73, ; 216..223
	i32 100, i32 123, i32 132, i32 67, i32 21, i32 55, i32 2, i32 72, ; 224..231
	i32 85, i32 56, i32 83, i32 88, i32 20, i32 101, i32 72, i32 143, ; 232..239
	i32 47, i32 10, i32 83, i32 130, i32 116, i32 66, i32 141, i32 134, ; 240..247
	i32 40, i32 61, i32 56, i32 90, i32 10, i32 64, i32 74, i32 60, ; 248..255
	i32 60, i32 96, i32 69, i32 118, i32 104, i32 7, i32 46, i32 100, ; 256..263
	i32 116, i32 80, i32 93, i32 87, i32 110, i32 63, i32 47, i32 65, ; 264..271
	i32 89, i32 29, i32 28, i32 79, i32 127, i32 8, i32 44, i32 135, ; 272..279
	i32 130, i32 142, i32 133, i32 58, i32 38, i32 125, i32 33, i32 91 ; 288..287
], align 16

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 16; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1}
!llvm.ident = !{!2}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
