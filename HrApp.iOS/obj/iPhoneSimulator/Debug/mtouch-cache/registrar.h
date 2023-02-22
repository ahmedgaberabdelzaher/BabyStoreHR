#pragma clang diagnostic ignored "-Wdeprecated-declarations"
#pragma clang diagnostic ignored "-Wtypedef-redefinition"
#pragma clang diagnostic ignored "-Wobjc-designated-initializers"
#pragma clang diagnostic ignored "-Wunguarded-availability-new"
#define DEBUG 1
#include <stdarg.h>
#include <objc/objc.h>
#include <objc/runtime.h>
#include <objc/message.h>
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <WebKit/WebKit.h>
#import <SafariServices/SafariServices.h>
#import <ContactsUI/ContactsUI.h>
#import <UserNotifications/UserNotifications.h>
#import <Photos/Photos.h>
#import <MediaPlayer/MediaPlayer.h>
#import <GLKit/GLKit.h>
#import <CoreTelephony/CoreTelephonyDefines.h>
#import <CoreTelephony/CTCall.h>
#import <CoreTelephony/CTCallCenter.h>
#import <CoreTelephony/CTCarrier.h>
#import <CoreTelephony/CTTelephonyNetworkInfo.h>
#import <CoreTelephony/CTSubscriber.h>
#import <CoreTelephony/CTSubscriberInfo.h>
#import <CoreSpotlight/CoreSpotlight.h>
#import <CoreLocation/CoreLocation.h>
#import <QuartzCore/QuartzCore.h>
#import <Contacts/Contacts.h>
#import <AuthenticationServices/AuthenticationServices.h>
#import <AVKit/AVKit.h>
#import <AVFoundation/AVFoundation.h>
#import <CoreGraphics/CoreGraphics.h>

@class Xamarin_Forms_Platform_iOS_NavigationRenderer;
@class HrApp_iOS_CustomNaviPageRenderer;
@class Xamarin_Forms_Platform_iOS_PageRenderer;
@class HrApp_iOS_CustomPageRenderer;
@class Xamarin_Forms_Platform_iOS_WkWebViewRenderer;
@class HrApp_iOS_CustomWebViewRenderer;
@class UIApplicationDelegate;
@class Xamarin_Forms_Platform_iOS_FormsApplicationDelegate;
@class AppDelegate;
@class MyViewController;
@class SFSafariViewControllerDelegate;
@class CNContactPickerDelegate;
@class GLKViewDelegate;
@class WKNavigationDelegate;
@class WKUIDelegate;
@class Foundation_NSDispatcher;
@class __MonoMac_NSActionDispatcher;
@class __MonoMac_NSSynchronizationContextDispatcher;
@class __Xamarin_NSTimerActionDispatcher;
@class Foundation_NSAsyncDispatcher;
@class __MonoMac_NSAsyncActionDispatcher;
@class __MonoMac_NSAsyncSynchronizationContextDispatcher;
@class Foundation_InternalNSNotificationHandler;
@class NSURLSessionDataDelegate;
@class CLLocationManagerDelegate;
@class CAAnimationDelegate;
@class UIAdaptivePresentationControllerDelegate;
@class UIKit_UIControlEventProxy;
@class UIPopoverPresentationControllerDelegate;
@protocol UIAccessibilityContainer;
@class UIActionSheetDelegate;
@class UIActivityItemSource;
@class UIAlertViewDelegate;
@class UICollectionViewDelegateFlowLayout;
@class UIDocumentPickerDelegate;
@class UIGestureRecognizerDelegate;
@class UINavigationControllerDelegate;
@class UIImagePickerControllerDelegate;
@class UIPickerViewModel;
@class UIScrollViewDelegate;
@class UISearchResultsUpdating;
@class UISplitViewControllerDelegate;
@class UITableViewSource;
@class UITextFieldDelegate;
@class UITextViewDelegate;
@class System_Net_Http_NSUrlSessionHandler_WrappedNSInputStream;
@class GLKit_GLKView__GLKViewDelegate;
@class __NSObject_Disposer;
@class __XamarinObjectObserver;
@class CoreAnimation_CAAnimation__CAAnimationDelegate;
@class UIKit_UIAlertView__UIAlertViewDelegate;
@class UIKit_UIBarButtonItem_Callback;
@class UIKit_UIBarItem_UIBarItemAppearance;
@class UIKit_UIBarButtonItem_UIBarButtonItemAppearance;
@class UIKit_UIView_UIViewAppearance;
@class UIKit_UIControl_UIControlAppearance;
@class UIKit_UIButton_UIButtonAppearance;
@class UIKit_UIDocumentPickerViewController__UIDocumentPickerDelegate;
@class __UIGestureRecognizerToken;
@class __UIGestureRecognizerGenericCB;
@class __UIGestureRecognizerParameterlessToken;
@class UIKit_UIGestureRecognizer__UIGestureRecognizerDelegate;
@class UIKit_UINavigationBar_UINavigationBarAppearance;
@class UIKit_UIPopoverPresentationController__UIPopoverPresentationControllerDelegate;
@class UIKit_UISearchBar__UISearchBarDelegate;
@class UIKit_UISearchController___Xamarin_UISearchResultsUpdating;
@class UIKit_UIScrollView_UIScrollViewAppearance;
@class UIKit_UITableView_UITableViewAppearance;
@class UIKit_UITextField__UITextFieldDelegate;
@class UIKit_UIScrollView__UIScrollViewDelegate;
@class UIKit_UITextView__UITextViewDelegate;
@class UIKit_UITextView_UITextViewAppearance;
@class UIKit_UIToolbar_UIToolbarAppearance;
@class UIKit_UISplitViewController__UISplitViewControllerDelegate;
@class UIKit_UISwitch_UISwitchAppearance;
@class UIKit_UITabBar_UITabBarAppearance;
@class UIKit_UITabBarController__UITabBarControllerDelegate;
@class System_Net_Http_NSUrlSessionHandler_NSUrlSessionHandlerDelegate;
@class Xamarin_Forms_Platform_iOS_iOS7ButtonContainer;
@class Xamarin_Forms_Platform_iOS_GlobalCloseContextGestureRecognizer;
@class Xamarin_Forms_Platform_iOS_PlatformRenderer;
@class Xamarin_Forms_Platform_iOS_VisualElementRenderer_1;
@class Xamarin_Forms_Platform_iOS_ViewRenderer_2;
@class Xamarin_Forms_Platform_iOS_ViewRenderer;
@class Xamarin_Forms_Platform_iOS_CellTableViewCell;
@class Xamarin_Forms_Platform_iOS_ActivityIndicatorRenderer;
@class Xamarin_Forms_Platform_iOS_BoxRenderer;
@class Xamarin_Forms_Platform_iOS_ButtonRenderer;
@class Xamarin_Forms_Platform_iOS_NoCaretField;
@class Xamarin_Forms_Platform_iOS_DatePickerRendererBase_1;
@class Xamarin_Forms_Platform_iOS_DatePickerRenderer;
@class Xamarin_Forms_Platform_iOS_EditorRendererBase_1;
@class Xamarin_Forms_Platform_iOS_EditorRenderer;
@class Xamarin_Forms_Platform_iOS_EntryRendererBase_1;
@class Xamarin_Forms_Platform_iOS_EntryRenderer;
@class Xamarin_Forms_Platform_iOS_HeaderWrapperView;
@class Xamarin_Forms_Platform_iOS_FormsRefreshControl;
@class Xamarin_Forms_Platform_iOS_ReadOnlyField;
@class Xamarin_Forms_Platform_iOS_PickerRendererBase_1;
@class Xamarin_Forms_Platform_iOS_PickerRenderer;
@class Xamarin_Forms_Platform_iOS_ProgressBarRenderer;
@class Xamarin_Forms_Platform_iOS_ScrollViewRenderer;
@class Xamarin_Forms_Platform_iOS_SearchBarRenderer;
@class Xamarin_Forms_Platform_iOS_SliderRenderer;
@class Xamarin_Forms_Platform_iOS_StepperRenderer;
@class Xamarin_Forms_Platform_iOS_SwitchRenderer;
@class Xamarin_Forms_Platform_iOS_TableViewModelRenderer;
@class Xamarin_Forms_Platform_iOS_UnEvenTableViewModelRenderer;
@class Xamarin_Forms_Platform_iOS_TableViewRenderer;
@class Xamarin_Forms_Platform_iOS_TimePickerRendererBase_1;
@class Xamarin_Forms_Platform_iOS_TimePickerRenderer;
@class Xamarin_Forms_Platform_iOS_ItemsViewDelegator_2;
@class Xamarin_Forms_Platform_iOS_CarouselViewDelegator;
@class Xamarin_Forms_Platform_iOS_ItemsViewRenderer_2;
@class Xamarin_Forms_Platform_iOS_CarouselViewRenderer;
@class Xamarin_Forms_Platform_iOS_StructuredItemsViewRenderer_2;
@class Xamarin_Forms_Platform_iOS_SelectableItemsViewRenderer_2;
@class Xamarin_Forms_Platform_iOS_GroupableItemsViewRenderer_2;
@class Xamarin_Forms_Platform_iOS_CollectionViewRenderer;
@class Xamarin_Forms_Platform_iOS_ItemsViewController_1;
@class Xamarin_Forms_Platform_iOS_StructuredItemsViewController_1;
@class Xamarin_Forms_Platform_iOS_SelectableItemsViewController_1;
@class Xamarin_Forms_Platform_iOS_GroupableItemsViewController_1;
@class Xamarin_Forms_Platform_iOS_SelectableItemsViewDelegator_2;
@class Xamarin_Forms_Platform_iOS_GroupableItemsViewDelegator_2;
@class Xamarin_Forms_Platform_iOS_ItemsViewCell;
@class Xamarin_Forms_Platform_iOS_TemplatedCell;
@class Xamarin_Forms_Platform_iOS_HeightConstrainedTemplatedCell;
@class Xamarin_Forms_Platform_iOS_HorizontalCell;
@class Xamarin_Forms_Platform_iOS_DefaultCell;
@class Xamarin_Forms_Platform_iOS_HorizontalDefaultSupplementalView;
@class Xamarin_Forms_Platform_iOS_HorizontalSupplementaryView;
@class Xamarin_Forms_Platform_iOS_HorizontalDefaultCell;
@class Xamarin_Forms_Platform_iOS_WidthConstrainedTemplatedCell;
@class Xamarin_Forms_Platform_iOS_VerticalCell;
@class Xamarin_Forms_Platform_iOS_VerticalDefaultCell;
@class Xamarin_Forms_Platform_iOS_ItemsViewLayout;
@class Xamarin_Forms_Platform_iOS_GridViewLayout;
@class Xamarin_Forms_Platform_iOS_ListViewLayout;
@class Xamarin_Forms_Platform_iOS_VerticalDefaultSupplementalView;
@class Xamarin_Forms_Platform_iOS_VerticalSupplementaryView;
@class Xamarin_Forms_Platform_iOS_FormsCAKeyFrameAnimation;
@class Xamarin_Forms_Platform_iOS_FormsCheckBox;
@class Xamarin_Forms_Platform_iOS_FormsUIImageView;
@class Xamarin_Forms_Platform_iOS_NativeViewWrapperRenderer;
@class Xamarin_Forms_Platform_iOS_PageContainer;
@class Xamarin_Forms_Platform_iOS_CheckBoxRendererBase_1;
@class Xamarin_Forms_Platform_iOS_PhoneFlyoutPageRenderer;
@class Xamarin_Forms_Platform_iOS_PhoneMasterDetailRenderer;
@class Xamarin_Forms_Platform_iOS_ChildViewController;
@class Xamarin_Forms_Platform_iOS_TabletFlyoutPageRenderer;
@class Xamarin_Forms_Platform_iOS_TabletMasterDetailRenderer;
@class Xamarin_Forms_Platform_iOS_ShellItemRenderer;
@class Xamarin_Forms_Platform_iOS_ShellSearchResultsRenderer;
@class Xamarin_Forms_Platform_iOS_ShellTableViewController;
@class Xamarin_Forms_Platform_iOS_UIContainerCell;
@class Xamarin_Forms_Platform_iOS_UIContainerView;
@class Xamarin_Forms_Platform_iOS_NativeViewPropertyListener;
@class Xamarin_Forms_Platform_iOS_CheckBoxRenderer;
@class Xamarin_Forms_Platform_iOS_CarouselViewLayout;
@class Xamarin_Forms_Platform_iOS_CarouselViewController;
@class Xamarin_Forms_Platform_iOS_CarouselTemplatedCell;
@class Xamarin_Forms_Platform_iOS_RefreshViewRenderer;
@class Xamarin_Forms_Platform_iOS_IndicatorViewRenderer;
@class Xamarin_Forms_Platform_iOS_FormsPageControl;
@class Xamarin_Forms_Platform_iOS_ShapeRenderer_2;
@class Xamarin_Forms_Platform_iOS_ShapeView;
@class Xamarin_Forms_Platform_iOS_ShapeLayer;
@class Xamarin_Forms_Platform_iOS_PathRenderer;
@class Xamarin_Forms_Platform_iOS_PathView;
@class Xamarin_Forms_Platform_iOS_EllipseRenderer;
@class Xamarin_Forms_Platform_iOS_EllipseView;
@class Xamarin_Forms_Platform_iOS_LineRenderer;
@class Xamarin_Forms_Platform_iOS_LineView;
@class Xamarin_Forms_Platform_iOS_PolygonRenderer;
@class Xamarin_Forms_Platform_iOS_PolygonView;
@class Xamarin_Forms_Platform_iOS_PolylineRenderer;
@class Xamarin_Forms_Platform_iOS_PolylineView;
@class Xamarin_Forms_Platform_iOS_RectangleRenderer;
@class Xamarin_Forms_Platform_iOS_RectangleView;
@class Xamarin_Forms_Platform_iOS_ShellFlyoutHeaderContainer;
@class Xamarin_Forms_Platform_iOS_ContextActionsCell_SelectGestureRecognizer;
@class Xamarin_Forms_Platform_iOS_ContextActionsCell_MoreActionSheetController;
@class Xamarin_Forms_Platform_iOS_ContextActionsCell_MoreActionSheetDelegate;
@class Xamarin_Forms_Platform_iOS_ContextActionsCell;
@class Xamarin_Forms_Platform_iOS_ContextScrollViewDelegate;
@class Xamarin_Forms_Platform_iOS_Platform_DefaultRenderer;
@class Xamarin_Forms_Platform_iOS_EntryCellRenderer_EntryCellTableViewCell;
@class Xamarin_Forms_Platform_iOS_ViewCellRenderer_ViewTableCell;
@class Xamarin_Forms_Platform_iOS_CarouselPageRenderer_CarouselPageContainer;
@class Xamarin_Forms_Platform_iOS_CarouselPageRenderer;
@class Xamarin_Forms_Platform_iOS_EditorRendererBase_1_FormsUITextView;
@class Xamarin_Forms_Platform_iOS_FrameRenderer_FrameView;
@class Xamarin_Forms_Platform_iOS_FrameRenderer;
@class Xamarin_Forms_Platform_iOS_ImageRenderer;
@class Xamarin_Forms_Platform_iOS_LabelRenderer_FormsLabel;
@class Xamarin_Forms_Platform_iOS_LabelRenderer;
@class Xamarin_Forms_Platform_iOS_ListViewRenderer_ListViewDataSource;
@class Xamarin_Forms_Platform_iOS_ListViewRenderer_UnevenListViewDataSource;
@class Xamarin_Forms_Platform_iOS_ListViewRenderer;
@class Xamarin_Forms_Platform_iOS_FormsUITableViewController;
@class Xamarin_Forms_Platform_iOS_NavigationRenderer_FormsNavigationBar;
@class Xamarin_Forms_Platform_iOS_NavigationRenderer_Container;
@class Xamarin_Forms_Platform_iOS_OpenGLViewRenderer_Delegate;
@class Xamarin_Forms_Platform_iOS_OpenGLViewRenderer;
@class Xamarin_Forms_Platform_iOS_PickerRendererBase_1_PickerSource;
@class Xamarin_Forms_Platform_iOS_TabbedRenderer;
@class Xamarin_Forms_Platform_iOS_DragAndDropDelegate_CustomLocalStateData;
@class Xamarin_Forms_Platform_iOS_DragAndDropDelegate;
@class Xamarin_Forms_Platform_iOS_ModalWrapper;
@class Xamarin_Forms_Platform_iOS_PhoneFlyoutPageRenderer_ChildViewController;
@class Xamarin_Forms_Platform_iOS_EventedViewController_FlyoutView;
@class Xamarin_Forms_Platform_iOS_EventedViewController;
@class Xamarin_Forms_Platform_iOS_TabletFlyoutPageRenderer_InnerDelegate;
@class Xamarin_Forms_Platform_iOS_ShellFlyoutContentRenderer;
@class Xamarin_Forms_Platform_iOS_ShellFlyoutRenderer;
@class Xamarin_Forms_Platform_iOS_ShellPageRendererTracker_TitleViewContainer;
@class Xamarin_Forms_Platform_iOS_ShellRenderer;
@class Xamarin_Forms_Platform_iOS_ShellSectionRootHeader_ShellSectionHeaderCell;
@class Xamarin_Forms_Platform_iOS_ShellSectionRootHeader;
@class Xamarin_Forms_Platform_iOS_ShellSectionRootRenderer;
@class Xamarin_Forms_Platform_iOS_ShellSectionRenderer_GestureDelegate;
@class Xamarin_Forms_Platform_iOS_ShellSectionRenderer_NavDelegate;
@class Xamarin_Forms_Platform_iOS_ShellSectionRenderer;
@class Xamarin_Forms_Platform_iOS_ShellTableViewSource_SeparatorView;
@class Xamarin_Forms_Platform_iOS_ShellTableViewSource;
@class Xamarin_Forms_Platform_iOS_ImageButtonRenderer;
@class Xamarin_Forms_Platform_iOS_SwipeViewRenderer;
@class Xamarin_Forms_Platform_iOS_ToolbarItemExtensions_PrimaryToolbarItem;
@class Xamarin_Forms_Platform_iOS_ToolbarItemExtensions_SecondaryToolbarItem_SecondaryToolbarItemContent;
@class Xamarin_Forms_Platform_iOS_ToolbarItemExtensions_SecondaryToolbarItem;
@class Xamarin_Forms_Platform_iOS_NavigationRenderer_SecondaryToolbar;
@class Xamarin_Forms_Platform_iOS_NavigationRenderer_ParentingViewController;
@class Xamarin_Forms_Platform_iOS_WkWebViewRenderer_CustomWebViewNavigationDelegate;
@class Xamarin_Forms_Platform_iOS_WkWebViewRenderer_CustomWebViewUIDelegate;
@protocol FIRMessagingDelegate;
@class Plugin_FirebasePushNotification_FirebasePushNotificationManager;
@class FIRMessagingMessageInfo;
@class ApiDefinition__Firebase_CloudMessaging_MessagingDelegate;
@class FIRMessagingExtensionHelper;
@class FIRMessagingRemoteMessage;
@class FIRMessaging;
@class FIRApp;
@class FIRConfiguration;
@class FIROptions;
@class FIRInstallationsAuthTokenResult;
@class FIRInstallations;
@class FIRInstanceIDResult;
@class FIRInstanceID;
@class Xamarin_Essentials_ShareActivityItemSource;
@class Xamarin_Essentials_AuthManager;
@class Xamarin_Essentials_SingleLocationListener;
@class Xamarin_Essentials_Contacts_ContactPickerDelegate;
@class Xamarin_Essentials_FilePicker_PickerDelegate;
@class Xamarin_Essentials_MediaPicker_PhotoPickerDelegate;
@class Xamarin_Essentials_Platform_UIPresentationControllerDelegate;
@class Xamarin_Essentials_WebAuthenticator_NativeSFSafariViewControllerDelegate;
@class Xamarin_Essentials_WebAuthenticator_ContextProvider;
@class Xamarin_Essentials_Permissions_LocationWhenInUse_ManagerDelegate;
@class OpenTK_Platform_iPhoneOS_CADisplayLinkTimeSource;
@class OpenTK_Platform_iPhoneOS_iPhoneOSGameView;
@class Xamarin_Forms_PancakeView_iOS_PancakeViewRenderer;
@class Xamarin_CommunityToolkit_Views_Snackbar_Helpers_NativeRoundedStackView;
@class Xamarin_CommunityToolkit_iOS_UI_Views_SideMenuViewRenderer;
@class Xamarin_CommunityToolkit_iOS_Effects_TouchEventsGestureRecognizer;
@class Xamarin_CommunityToolkit_iOS_Effects_ShouldRecognizeSimultaneouslyRecognizerDelegate;
@class Xamarin_CommunityToolkit_UI_Views_PhotoCaptureDelegate;
@class Xamarin_CommunityToolkit_UI_Views_MediaElementRenderer;
@class Xamarin_CommunityToolkit_UI_Views_SemanticOrderViewRenderer;
@class Xamarin_CommunityToolkit_UI_Views_ImageSwitcherRenderer;
@class Xamarin_CommunityToolkit_UI_Views_TextSwitcherRenderer;
@class Xamarin_CommunityToolkit_UI_Views_Helpers_PaddedLabel;
@class Xamarin_CommunityToolkit_UI_Views_Helpers_iOS_SnackBar_BaseSnackBarView;
@class Xamarin_CommunityToolkit_UI_Views_Helpers_iOS_SnackBarViews_MessageSnackBarView;
@class Xamarin_CommunityToolkit_UI_Views_Helpers_iOS_ActionMessageSnackBarView;
@class Xamarin_CommunityToolkit_Views_Snackbar_Helpers_NativeSnackButton;
@class Xamarin_CommunityToolkit_iOS_Effects_TouchUITapGestureRecognizer;
@class Xamarin_CommunityToolkit_iOS_Effects_TouchUITapGestureRecognizerDelegate;
@class Xamarin_CommunityToolkit_UI_Views_CameraViewRenderer;
@class Xamarin_CommunityToolkit_UI_Views_FormsCameraView;
@class Xamarin_CommunityToolkit_UI_Views_DrawingViewRenderer;
@class Xamarin_CommunityToolkit_UI_Views_PopupRenderer_PopoverDelegate;
@class Xamarin_CommunityToolkit_UI_Views_PopupRenderer;
@class ImageCircle_Forms_Plugin_iOS_ImageCircleRenderer;
@class XamSvg_XamForms_iOS_SvgImageRenderer;
@class UISvgImageView;
@class AiForms_Effects_iOS_NumberPickerSource;
@class AiForms_Effects_iOS_PaddingLabel;
@class AiForms_Effects_iOS_NoCaretField;
@class AiForms_Effects_iOS_TouchEffectGestureRecognizer;
@class AiForms_Effects_iOS_AlwaysSimultaneouslyGestureRecognizerDelegate;
@class IQKeyboardManager;
@class IQKeyboardReturnKeyHandler;
@protocol UIView_IQToolbarAddition;
@class Xamarin_IQBarButtonItem_IQBarButtonItemAppearance;
@class IQBarButtonItem;
@class Xamarin_IQPreviousNextView_IQPreviousNextViewAppearance;
@class IQPreviousNextView;
@class Xamarin_IQTextView_IQTextViewAppearance;
@class IQTextView;
@class Xamarin_IQTitleBarButtonItem_IQTitleBarButtonItemAppearance;
@class IQTitleBarButtonItem;
@class Xamarin_IQToolbar_IQToolbarAppearance;
@class IQToolbar;
@class Xamarin_UIView_IQToolbarAddition_UIView_IQToolbarAdditionAppearance;
@class Syncfusion_SfPdfViewer_XForms_iOS_InkViewPanGestureDelegate;
@class Syncfusion_SfPdfViewer_XForms_iOS_CustomViewBorder;
@class Syncfusion_SfPdfViewer_XForms_iOS_CustomViewBubble;
@class Syncfusion_SfPdfViewer_XForms_iOS_CustomViewHolder;
@class Syncfusion_SfPdfViewer_XForms_iOS_CustomViewSelection;
@class Syncfusion_SfPdfViewer_XForms_iOS_StampIcon;
@class Syncfusion_SfPdfViewer_XForms_iOS_TextBubbleView;
@class Syncfusion_SfPdfViewer_XForms_iOS_SelectionBorderView;
@class Syncfusion_SfPdfViewer_XForms_iOS_TextSelectionView;
@class Syncfusion_SfPdfViewer_XForms_iOS_TextView;
@class Syncfusion_SfPdfViewer_XForms_iOS_ListPopupView;
@class Syncfusion_SfPdfViewer_XForms_iOS_PopupListCell;
@class Syncfusion_SfPdfViewer_XForms_iOS_PopupListSource;
@class Syncfusion_SfPdfViewer_XForms_iOS_PdfWidget;
@class Syncfusion_SfPdfViewer_XForms_iOS_PdfTextField;
@class Syncfusion_SfPdfViewer_XForms_iOS_PdfTextFieldDelegate;
@class Syncfusion_SfPdfViewer_XForms_iOS_PdfCheckBox;
@class Syncfusion_SfPdfViewer_XForms_iOS_PdfComboBox;
@class Syncfusion_SfPdfViewer_XForms_iOS_PdfListBox;
@class Syncfusion_SfPdfViewer_XForms_iOS_ListBoxSource;
@class Syncfusion_SfPdfViewer_XForms_iOS_PdfRadioButton;
@class Syncfusion_SfPdfViewer_XForms_iOS_ShapeSelectBorderView;
@class Syncfusion_SfPdfViewer_XForms_iOS_ShapeSelectionView;
@class Syncfusion_SfPdfViewer_XForms_iOS_SignaturePad;
@class Syncfusion_SfPdfViewer_XForms_iOS_SignatureView;
@class PdfContentView;
@class CurrentHighlightedView;
@class Syncfusion_SfPdfViewer_XForms_iOS_AlertViewDelegate;
@class Syncfusion_SfPdfViewer_XForms_iOS_AlertViewTextBoxDelegate;
@class Syncfusion_SfPdfViewer_XForms_iOS_CustomSearchRenderer;
@class Syncfusion_SfPdfViewer_XForms_iOS_CustomPageRenderer;
@class Syncfusion_SfPdfViewer_XForms_iOS_EditTextPopup;
@class Syncfusion_SfPdfViewer_XForms_iOS_HyperlinkAnnotation;
@class Syncfusion_SfPdfViewer_XForms_iOS_BubbleView;
@class Syncfusion_SfPdfViewer_XForms_iOS_InkSetting;
@class Syncfusion_SfPdfViewer_XForms_iOS_SelectBorderView;
@class Syncfusion_SfPdfViewer_XForms_iOS_SelectionView;
@class Syncfusion_SfPdfViewer_XForms_iOS_PasswordDialogView;
@class Syncfusion_SfPdfViewer_XForms_iOS_SfLabelRendererIOS;
@class Syncfusion_SfPdfViewer_XForms_iOS_SfFontButtonRenderer;
@class Syncfusion_SfPdfViewer_XForms_iOS_SfPdfDocumentViewRenderer;
@class Syncfusion_SfPdfViewer_XForms_iOS_MaterialSfPdfDocumentViewRenderer;
@class Syncfusion_SfPdfViewer_XForms_iOS_CustomStackLayoutRendereriOS;
@class Syncfusion_SfPdfViewer_XForms_iOS_SliderCustomRenderer;
@class Syncfusion_SfPdfViewer_XForms_iOS_ImageAndCanvasContainer;
@class Syncfusion_SfPdfViewer_XForms_iOS_PageScrollView;
@class Syncfusion_SfPdfViewer_XForms_iOS_PageScrollViewContainer;
@class Syncfusion_SfPdfViewer_XForms_iOS_SinglePageViewer;
@class Syncfusion_SfPdfViewer_XForms_iOS_SfPdfVieweriOS;
@class Syncfusion_SfPdfViewer_XForms_iOS_PasswordTextFieldDelegate;
@class Syncfusion_SfPdfViewer_XForms_iOS_PdfButton;
@class Syncfusion_SfPdfViewer_XForms_iOS_StampRendererView;
@class Syncfusion_SfPdfViewer_XForms_iOS_SignatureField;
@class Syncfusion_SfPdfViewer_XForms_iOS_ArrowAnnotationSettings;
@class Syncfusion_SfPdfViewer_XForms_iOS_CircleAnnotationSettings;
@class Syncfusion_SfPdfViewer_XForms_iOS_DummyView;
@class Syncfusion_SfPdfViewer_XForms_iOS_LineAnnotationSettings;
@class Syncfusion_SfPdfViewer_XForms_iOS_PolygonAnnotationView;
@class Syncfusion_SfPdfViewer_XForms_iOS_RectangleAnnotationSettings;
@class Syncfusion_SfPdfViewer_XForms_iOS_ShapeBubbleView;
@class Syncfusion_SfPdfViewer_XForms_iOS_ImageViewEx;
@class Syncfusion_SfPdfViewer_XForms_iOS_ScrollHead;
@class Syncfusion_SfPdfViewer_XForms_iOS_ScrollViewEx;
@class Syncfusion_SfPdfViewer_XForms_iOS_StackViewEx;
@class TransparentCanvas;
@class Syncfusion_SfPdfViewer_XForms_iOS_InkGroup;
@class Bubble;
@class SfBusyIndicator;
@class Syncfusion_SfBusyIndicator_iOS_SFBusyIndicator;
@class Syncfusion_XForms_iOS_Graphics_SfGradientViewRenderer;
@class Syncfusion_XForms_iOS_Shimmer_SfShimmerRenderer;
@class Syncfusion_XForms_iOS_Shimmer_ShimmerViewRenderer;
@class Syncfusion_XForms_iOS_TextInputLayout_InputLayoutBorderRenderer;
@class Syncfusion_XForms_iOS_TextInputLayout_InputLayoutToggleViewRenderer;
@class Syncfusion_XForms_iOS_TextInputLayout_SfTextInputLayoutRenderer;
@class Syncfusion_XForms_iOS_TextInputLayout_InputLayoutBorder;
@class Syncfusion_XForms_iOS_TextInputLayout_InputLayoutClearButtonViewRenderer;
@class Syncfusion_XForms_iOS_Core_FontIconLabelRenderer;
@class Syncfusion_XForms_iOS_EffectsView_SfEffectsViewLayer;
@class Syncfusion_XForms_iOS_Shimmer_ShimmerWaveLayer;
@class Syncfusion_XForms_iOS_Border_SfBorderRenderer;
@class Syncfusion_XForms_iOS_EffectsView_SfEffectsViewRenderer;
@class Syncfusion_SfRangeSlider_XForms_iOS_SfRangeSliderRenderer;
@class Syncfusion_SfRangeSlider_XForms_iOS_SfRangeSliderVisualRenderer;
@class Syncfusion_SfRangeSlider_iOS_SfLabelItems;
@class Syncfusion_SfRangeSlider_iOS_SFLabelItems;
@class Syncfusion_SfRangeSlider_iOS_SfRangeKnobLayer;
@class SfRangeSlider;
@class Syncfusion_SfRangeSlider_iOS_SFRangeSlider;
@class Syncfusion_SfRangeSlider_iOS_SfRangeTickLayer;
@class Syncfusion_SfRangeSlider_iOS_SfRangeTracker;
@class Syncfusion_SfRangeSlider_iOS_SfThumb;
@class Syncfusion_SfRangeSlider_iOS_SFThumb;
@class Syncfusion_SfRangeSlider_iOS_SfThumbItem;
@class Syncfusion_SfRangeSlider_iOS_SFThumbItem;
@class Syncfusion_SfRangeSlider_iOS_CustomRangePanGesture;
@class Syncfusion_SfRangeSlider_iOS_BalloonLayer;
@class XamForms_Controls_iOS_CalendarButtonRenderer;

@interface Xamarin_Forms_Platform_iOS_NavigationRenderer : UINavigationController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) didRotateFromInterfaceOrientation:(NSInteger)p0;
	-(NSArray *) popToRootViewControllerAnimated:(BOOL)p0;
	-(UIViewController *) popViewControllerAnimated:(BOOL)p0;
	-(void) viewDidAppear:(BOOL)p0;
	-(void) viewWillAppear:(BOOL)p0;
	-(void) viewDidDisappear:(BOOL)p0;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidLoad;
	-(void) traitCollectionDidChange:(UITraitCollection *)p0;
	-(UIViewController *) childViewControllerForStatusBarHidden;
	-(UIViewController *) childViewControllerForHomeIndicatorAutoHidden;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface HrApp_iOS_CustomNaviPageRenderer : Xamarin_Forms_Platform_iOS_NavigationRenderer {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_PageRenderer : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) loadView;
	-(void) viewWillLayoutSubviews;
	-(void) viewDidLayoutSubviews;
	-(void) viewSafeAreaInsetsDidChange;
	-(void) viewDidAppear:(BOOL)p0;
	-(void) viewDidDisappear:(BOOL)p0;
	-(void) viewDidLoad;
	-(void) viewWillDisappear:(BOOL)p0;
	-(NSInteger) preferredStatusBarUpdateAnimation;
	-(void) traitCollectionDidChange:(UITraitCollection *)p0;
	-(BOOL) prefersStatusBarHidden;
	-(BOOL) prefersHomeIndicatorAutoHidden;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface HrApp_iOS_CustomPageRenderer : Xamarin_Forms_Platform_iOS_PageRenderer {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_WkWebViewRenderer : WKWebView {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) didMoveToWindow;
	-(void) layoutSubviews;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface HrApp_iOS_CustomWebViewRenderer : Xamarin_Forms_Platform_iOS_WkWebViewRenderer {
}
	-(id) init;
@end

@interface UIApplicationDelegate : NSObject<UIApplicationDelegate> {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_FormsApplicationDelegate : NSObject<UIApplicationDelegate> {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIWindow *) window;
	-(void) setWindow:(UIWindow *)p0;
	-(BOOL) application:(UIApplication *)p0 continueUserActivity:(NSUserActivity *)p1 restorationHandler:(void (^)(id *))p2;
	-(void) applicationDidEnterBackground:(UIApplication *)p0;
	-(BOOL) application:(UIApplication *)p0 didFinishLaunchingWithOptions:(NSDictionary *)p1;
	-(void) applicationDidBecomeActive:(UIApplication *)p0;
	-(void) applicationWillResignActive:(UIApplication *)p0;
	-(void) application:(UIApplication *)p0 didUpdateUserActivity:(NSUserActivity *)p1;
	-(void) applicationWillEnterForeground:(UIApplication *)p0;
	-(BOOL) application:(UIApplication *)p0 willFinishLaunchingWithOptions:(NSDictionary *)p1;
	-(void) applicationWillTerminate:(UIApplication *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface AppDelegate : Xamarin_Forms_Platform_iOS_FormsApplicationDelegate<UIApplicationDelegate> {
}
	-(BOOL) application:(UIApplication *)p0 didFinishLaunchingWithOptions:(NSDictionary *)p1;
	-(void) application:(UIApplication *)p0 didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)p1;
	-(void) application:(UIApplication *)p0 didFailToRegisterForRemoteNotificationsWithError:(NSError *)p1;
	-(void) application:(UIApplication *)p0 didReceiveRemoteNotification:(NSDictionary *)p1 fetchCompletionHandler:(void (^)(void *))p2;
	-(id) init;
@end

@interface MyViewController : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) viewDidLoad;
	-(void) didReceiveMemoryWarning;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface SFSafariViewControllerDelegate : NSObject<SFSafariViewControllerDelegate> {
}
	-(id) init;
@end

@interface CNContactPickerDelegate : NSObject<CNContactPickerDelegate> {
}
	-(id) init;
@end

@interface GLKViewDelegate : NSObject<GLKViewDelegate> {
}
	-(id) init;
@end

@interface WKNavigationDelegate : NSObject<WKNavigationDelegate> {
}
	-(id) init;
@end

@interface WKUIDelegate : NSObject<WKUIDelegate> {
}
	-(id) init;
@end

@interface NSURLSessionDataDelegate : NSObject<NSURLSessionDataDelegate, NSURLSessionTaskDelegate, NSURLSessionDelegate> {
}
	-(id) init;
@end

@interface CLLocationManagerDelegate : NSObject<CLLocationManagerDelegate> {
}
	-(id) init;
@end

@interface CAAnimationDelegate : NSObject<CAAnimationDelegate> {
}
	-(id) init;
@end

@interface UIAdaptivePresentationControllerDelegate : NSObject<UIAdaptivePresentationControllerDelegate> {
}
	-(id) init;
@end

@interface UIPopoverPresentationControllerDelegate : NSObject<UIPopoverPresentationControllerDelegate, UIAdaptivePresentationControllerDelegate> {
}
	-(id) init;
@end

@protocol UIAccessibilityContainer
@end

@interface UIActionSheetDelegate : NSObject<UIActionSheetDelegate> {
}
	-(id) init;
@end

@interface UIActivityItemSource : NSObject<UIActivityItemSource> {
}
	-(id) init;
@end

@interface UIAlertViewDelegate : NSObject<UIAlertViewDelegate> {
}
	-(id) init;
@end

@interface UICollectionViewDelegateFlowLayout : NSObject<UICollectionViewDelegate, UICollectionViewDelegateFlowLayout, UICollectionViewDelegate> {
}
	-(id) init;
@end

@interface UIDocumentPickerDelegate : NSObject<UIDocumentPickerDelegate> {
}
	-(id) init;
@end

@interface UIGestureRecognizerDelegate : NSObject<UIGestureRecognizerDelegate> {
}
	-(id) init;
@end

@interface UINavigationControllerDelegate : NSObject<UINavigationControllerDelegate> {
}
	-(id) init;
@end

@interface UIImagePickerControllerDelegate : NSObject<UINavigationControllerDelegate, UIImagePickerControllerDelegate, UINavigationControllerDelegate> {
}
	-(id) init;
@end

@interface UIPickerViewModel : NSObject<UIPickerViewDataSource, UIPickerViewDelegate> {
}
	-(id) init;
@end

@interface UIScrollViewDelegate : NSObject<UIScrollViewDelegate> {
}
	-(id) init;
@end

@interface UISearchResultsUpdating : NSObject<UISearchResultsUpdating> {
}
	-(id) init;
@end

@interface UISplitViewControllerDelegate : NSObject<UISplitViewControllerDelegate> {
}
	-(id) init;
@end

@interface UITableViewSource : NSObject<UIScrollViewDelegate> {
}
	-(id) init;
@end

@interface UITextFieldDelegate : NSObject<UITextFieldDelegate> {
}
	-(id) init;
@end

@interface UITextViewDelegate : NSObject<UITextViewDelegate, UIScrollViewDelegate> {
}
	-(id) init;
@end

@interface UIKit_UIBarItem_UIBarItemAppearance : NSObject {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface UIKit_UIBarButtonItem_UIBarButtonItemAppearance : UIKit_UIBarItem_UIBarItemAppearance {
}
@end

@interface UIKit_UIView_UIViewAppearance : NSObject {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIColor *) backgroundColor;
	-(UIColor *) tintColor;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface UIKit_UIControl_UIControlAppearance : UIKit_UIView_UIViewAppearance {
}
@end

@interface UIKit_UIButton_UIButtonAppearance : UIKit_UIControl_UIControlAppearance {
}
	-(UIImage *) backgroundImageForState:(NSUInteger)p0;
	-(UIColor *) titleColorForState:(NSUInteger)p0;
	-(UIColor *) titleShadowColorForState:(NSUInteger)p0;
@end

@interface __UIGestureRecognizerToken : NSObject {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface __UIGestureRecognizerParameterlessToken : __UIGestureRecognizerToken {
}
	-(void) target;
@end

@interface UIKit_UINavigationBar_UINavigationBarAppearance : UIKit_UIView_UIViewAppearance {
}
	-(UIColor *) barTintColor;
	-(NSDictionary *) largeTitleTextAttributes;
	-(NSDictionary *) titleTextAttributes;
@end

@interface UIKit_UIScrollView_UIScrollViewAppearance : UIKit_UIView_UIViewAppearance {
}
@end

@interface UIKit_UITableView_UITableViewAppearance : UIKit_UIScrollView_UIScrollViewAppearance {
}
@end

@interface UIKit_UITextView_UITextViewAppearance : UIKit_UIScrollView_UIScrollViewAppearance {
}
@end

@interface UIKit_UIToolbar_UIToolbarAppearance : UIKit_UIView_UIViewAppearance {
}
@end

@interface UIKit_UISwitch_UISwitchAppearance : UIKit_UIControl_UIControlAppearance {
}
	-(UIColor *) onTintColor;
	-(UIColor *) thumbTintColor;
@end

@interface UIKit_UITabBar_UITabBarAppearance : UIKit_UIView_UIViewAppearance {
}
	-(UIColor *) selectedImageTintColor;
@end

@interface Xamarin_Forms_Platform_iOS_VisualElementRenderer_1 : UIView {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIColor *) backgroundColor;
	-(void) setBackgroundColor:(UIColor *)p0;
	-(BOOL) canBecomeFirstResponder;
	-(NSArray *) keyCommands;
	-(void) tabForward:(UIKeyCommand *)p0;
	-(void) tabBackward:(UIKeyCommand *)p0;
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(void) layoutSubviews;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ViewRenderer_2 : Xamarin_Forms_Platform_iOS_VisualElementRenderer_1 {
}
	-(void) layoutSubviews;
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(void) traitCollectionDidChange:(UITraitCollection *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_CellTableViewCell : UITableViewCell {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_ActivityIndicatorRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) drawRect:(CGRect)p0;
	-(void) layoutSubviews;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_BoxRenderer : Xamarin_Forms_Platform_iOS_VisualElementRenderer_1 {
}
	-(void) drawRect:(CGRect)p0;
	-(void) layoutSubviews;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ButtonRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(void) drawRect:(CGRect)p0;
	-(void) layoutSubviews;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_DatePickerRendererBase_1 : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_DatePickerRenderer : Xamarin_Forms_Platform_iOS_DatePickerRendererBase_1 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_EditorRendererBase_1 : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_EditorRenderer : Xamarin_Forms_Platform_iOS_EditorRendererBase_1 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_EntryRendererBase_1 : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_EntryRenderer : Xamarin_Forms_Platform_iOS_EntryRendererBase_1 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_FormsRefreshControl : UIRefreshControl {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) isHidden;
	-(void) setHidden:(BOOL)p0;
	-(void) beginRefreshing;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_PickerRendererBase_1 : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_PickerRenderer : Xamarin_Forms_Platform_iOS_PickerRendererBase_1 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ProgressBarRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ScrollViewRenderer : UIScrollView {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) layoutSubviews;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_SearchBarRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(void) traitCollectionDidChange:(UITraitCollection *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_SliderRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_StepperRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_SwitchRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_TableViewModelRenderer : NSObject<UIScrollViewDelegate> {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UITableViewCell *) tableView:(UITableView *)p0 cellForRowAtIndexPath:(NSIndexPath *)p1;
	-(CGFloat) tableView:(UITableView *)p0 heightForHeaderInSection:(NSInteger)p1;
	-(UIView *) tableView:(UITableView *)p0 viewForHeaderInSection:(NSInteger)p1;
	-(void) tableView:(UITableView *)p0 willDisplayHeaderView:(UIView *)p1 forSection:(NSInteger)p2;
	-(NSInteger) numberOfSectionsInTableView:(UITableView *)p0;
	-(void) tableView:(UITableView *)p0 didSelectRowAtIndexPath:(NSIndexPath *)p1;
	-(NSInteger) tableView:(UITableView *)p0 numberOfRowsInSection:(NSInteger)p1;
	-(NSArray *) sectionIndexTitlesForTableView:(UITableView *)p0;
	-(NSString *) tableView:(UITableView *)p0 titleForHeaderInSection:(NSInteger)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_UnEvenTableViewModelRenderer : Xamarin_Forms_Platform_iOS_TableViewModelRenderer<UIScrollViewDelegate> {
}
	-(CGFloat) tableView:(UITableView *)p0 heightForRowAtIndexPath:(NSIndexPath *)p1;
@end

@interface Xamarin_Forms_Platform_iOS_TableViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) layoutSubviews;
	-(void) traitCollectionDidChange:(UITraitCollection *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_TimePickerRendererBase_1 : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_TimePickerRenderer : Xamarin_Forms_Platform_iOS_TimePickerRendererBase_1 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ItemsViewDelegator_2 : NSObject<UICollectionViewDelegateFlowLayout, UICollectionViewDelegate, UICollectionViewDelegateFlowLayout, UICollectionViewDelegate> {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) scrollViewDidScroll:(UIScrollView *)p0;
	-(UIEdgeInsets) collectionView:(UICollectionView *)p0 layout:(UICollectionViewLayout *)p1 insetForSectionAtIndex:(NSInteger)p2;
	-(CGFloat) collectionView:(UICollectionView *)p0 layout:(UICollectionViewLayout *)p1 minimumInteritemSpacingForSectionAtIndex:(NSInteger)p2;
	-(CGFloat) collectionView:(UICollectionView *)p0 layout:(UICollectionViewLayout *)p1 minimumLineSpacingForSectionAtIndex:(NSInteger)p2;
	-(void) collectionView:(UICollectionView *)p0 didEndDisplayingCell:(UICollectionViewCell *)p1 forItemAtIndexPath:(NSIndexPath *)p2;
	-(CGSize) collectionView:(UICollectionView *)p0 layout:(UICollectionViewLayout *)p1 sizeForItemAtIndexPath:(NSIndexPath *)p2;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_CarouselViewDelegator : Xamarin_Forms_Platform_iOS_ItemsViewDelegator_2<UICollectionViewDelegateFlowLayout, UICollectionViewDelegate, UICollectionViewDelegateFlowLayout, UICollectionViewDelegate> {
}
	-(void) scrollViewDidScroll:(UIScrollView *)p0;
	-(void) scrollViewDidEndScrollingAnimation:(UIScrollView *)p0;
	-(void) scrollViewDidEndDecelerating:(UIScrollView *)p0;
	-(void) scrollViewWillBeginDragging:(UIScrollView *)p0;
	-(void) scrollViewDidEndDragging:(UIScrollView *)p0 willDecelerate:(BOOL)p1;
@end

@interface Xamarin_Forms_Platform_iOS_ItemsViewRenderer_2 : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_CarouselViewRenderer : Xamarin_Forms_Platform_iOS_ItemsViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_StructuredItemsViewRenderer_2 : Xamarin_Forms_Platform_iOS_ItemsViewRenderer_2 {
}
	-(void) layoutSubviews;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_SelectableItemsViewRenderer_2 : Xamarin_Forms_Platform_iOS_StructuredItemsViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_GroupableItemsViewRenderer_2 : Xamarin_Forms_Platform_iOS_SelectableItemsViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_CollectionViewRenderer : Xamarin_Forms_Platform_iOS_GroupableItemsViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ItemsViewController_1 : UICollectionViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UICollectionViewCell *) collectionView:(UICollectionView *)p0 cellForItemAtIndexPath:(NSIndexPath *)p1;
	-(NSInteger) collectionView:(UICollectionView *)p0 numberOfItemsInSection:(NSInteger)p1;
	-(void) viewDidLoad;
	-(void) viewWillAppear:(BOOL)p0;
	-(void) viewWillLayoutSubviews;
	-(NSInteger) numberOfSectionsInCollectionView:(UICollectionView *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_StructuredItemsViewController_1 : Xamarin_Forms_Platform_iOS_ItemsViewController_1 {
}
	-(void) viewWillLayoutSubviews;
@end

@interface Xamarin_Forms_Platform_iOS_SelectableItemsViewController_1 : Xamarin_Forms_Platform_iOS_StructuredItemsViewController_1 {
}
	-(void) collectionView:(UICollectionView *)p0 didSelectItemAtIndexPath:(NSIndexPath *)p1;
	-(void) collectionView:(UICollectionView *)p0 didDeselectItemAtIndexPath:(NSIndexPath *)p1;
@end

@interface Xamarin_Forms_Platform_iOS_GroupableItemsViewController_1 : Xamarin_Forms_Platform_iOS_SelectableItemsViewController_1 {
}
	-(UICollectionReusableView *) collectionView:(UICollectionView *)p0 viewForSupplementaryElementOfKind:(NSString *)p1 atIndexPath:(NSIndexPath *)p2;
@end

@interface Xamarin_Forms_Platform_iOS_SelectableItemsViewDelegator_2 : Xamarin_Forms_Platform_iOS_ItemsViewDelegator_2<UICollectionViewDelegateFlowLayout, UICollectionViewDelegate, UICollectionViewDelegateFlowLayout, UICollectionViewDelegate> {
}
	-(void) collectionView:(UICollectionView *)p0 didSelectItemAtIndexPath:(NSIndexPath *)p1;
	-(void) collectionView:(UICollectionView *)p0 didDeselectItemAtIndexPath:(NSIndexPath *)p1;
@end

@interface Xamarin_Forms_Platform_iOS_GroupableItemsViewDelegator_2 : Xamarin_Forms_Platform_iOS_SelectableItemsViewDelegator_2<UICollectionViewDelegateFlowLayout, UICollectionViewDelegate, UICollectionViewDelegateFlowLayout, UICollectionViewDelegate> {
}
	-(CGSize) collectionView:(UICollectionView *)p0 layout:(UICollectionViewLayout *)p1 referenceSizeForHeaderInSection:(NSInteger)p2;
	-(CGSize) collectionView:(UICollectionView *)p0 layout:(UICollectionViewLayout *)p1 referenceSizeForFooterInSection:(NSInteger)p2;
	-(void) scrollViewDidEndScrollingAnimation:(UIScrollView *)p0;
	-(UIEdgeInsets) collectionView:(UICollectionView *)p0 layout:(UICollectionViewLayout *)p1 insetForSectionAtIndex:(NSInteger)p2;
@end

@interface Xamarin_Forms_Platform_iOS_ItemsViewCell : UICollectionViewCell {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) initWithFrame:(CGRect)p0;
@end

@interface Xamarin_Forms_Platform_iOS_TemplatedCell : Xamarin_Forms_Platform_iOS_ItemsViewCell {
}
	-(UICollectionViewLayoutAttributes *) preferredLayoutAttributesFittingAttributes:(UICollectionViewLayoutAttributes *)p0;
	-(BOOL) isSelected;
	-(void) setSelected:(BOOL)p0;
	-(id) initWithFrame:(CGRect)p0;
@end

@interface Xamarin_Forms_Platform_iOS_DefaultCell : Xamarin_Forms_Platform_iOS_ItemsViewCell {
}
	-(id) initWithFrame:(CGRect)p0;
@end

@interface Xamarin_Forms_Platform_iOS_ItemsViewLayout : UICollectionViewFlowLayout {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) flipsHorizontallyInOppositeLayoutDirection;
	-(BOOL) shouldInvalidateLayoutForPreferredLayoutAttributes:(UICollectionViewLayoutAttributes *)p0 withOriginalAttributes:(UICollectionViewLayoutAttributes *)p1;
	-(CGPoint) targetContentOffsetForProposedContentOffset:(CGPoint)p0 withScrollingVelocity:(CGPoint)p1;
	-(UICollectionViewLayoutInvalidationContext *) invalidationContextForPreferredLayoutAttributes:(UICollectionViewLayoutAttributes *)p0 withOriginalAttributes:(UICollectionViewLayoutAttributes *)p1;
	-(void) prepareLayout;
	-(void) prepareForCollectionViewUpdates:(NSArray *)p0;
	-(CGPoint) targetContentOffsetForProposedContentOffset:(CGPoint)p0;
	-(void) finalizeCollectionViewUpdates;
	-(BOOL) shouldInvalidateLayoutForBoundsChange:(CGRect)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_GridViewLayout : Xamarin_Forms_Platform_iOS_ItemsViewLayout {
}
	-(CGSize) collectionViewContentSize;
	-(NSArray *) layoutAttributesForElementsInRect:(CGRect)p0;
	-(UICollectionViewLayoutInvalidationContext *) invalidationContextForPreferredLayoutAttributes:(UICollectionViewLayoutAttributes *)p0 withOriginalAttributes:(UICollectionViewLayoutAttributes *)p1;
@end

@interface Xamarin_Forms_Platform_iOS_ListViewLayout : Xamarin_Forms_Platform_iOS_ItemsViewLayout {
}
@end

@interface Xamarin_Forms_Platform_iOS_FormsCAKeyFrameAnimation : CAKeyframeAnimation {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_FormsCheckBox : UIButton {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) isEnabled;
	-(void) setEnabled:(BOOL)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_FormsUIImageView : UIImageView {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIImage *) image;
	-(void) setImage:(UIImage *)p0;
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(BOOL) isAnimating;
	-(void) startAnimating;
	-(void) stopAnimating;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_NativeViewWrapperRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) layoutSubviews;
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_CheckBoxRendererBase_1 : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) layoutSubviews;
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_PhoneFlyoutPageRenderer : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) viewDidAppear:(BOOL)p0;
	-(void) viewDidDisappear:(BOOL)p0;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidLoad;
	-(void) willRotateToInterfaceOrientation:(NSInteger)p0 duration:(double)p1;
	-(UIViewController *) childViewControllerForStatusBarHidden;
	-(UIViewController *) childViewControllerForHomeIndicatorAutoHidden;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_PhoneMasterDetailRenderer : Xamarin_Forms_Platform_iOS_PhoneFlyoutPageRenderer {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_TabletFlyoutPageRenderer : UISplitViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) viewDidAppear:(BOOL)p0;
	-(void) viewDidDisappear:(BOOL)p0;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidLoad;
	-(void) viewWillDisappear:(BOOL)p0;
	-(void) viewWillLayoutSubviews;
	-(void) willRotateToInterfaceOrientation:(NSInteger)p0 duration:(double)p1;
	-(UIViewController *) childViewControllerForStatusBarHidden;
	-(UIViewController *) childViewControllerForHomeIndicatorAutoHidden;
	-(void) viewWillTransitionToSize:(CGSize)p0 withTransitionCoordinator:(id)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_TabletMasterDetailRenderer : Xamarin_Forms_Platform_iOS_TabletFlyoutPageRenderer {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ShellItemRenderer : UITabBarController<UINavigationControllerDelegate> {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIViewController *) selectedViewController;
	-(void) setSelectedViewController:(UIViewController *)p0;
	-(void) navigationController:(UINavigationController *)p0 didShowViewController:(UIViewController *)p1 animated:(BOOL)p2;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidLoad;
	-(void) viewWillLayoutSubviews;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_ShellSearchResultsRenderer : UITableViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UITableViewCell *) tableView:(UITableView *)p0 cellForRowAtIndexPath:(NSIndexPath *)p1;
	-(void) tableView:(UITableView *)p0 didSelectRowAtIndexPath:(NSIndexPath *)p1;
	-(NSInteger) numberOfSectionsInTableView:(UITableView *)p0;
	-(NSInteger) tableView:(UITableView *)p0 numberOfRowsInSection:(NSInteger)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_ShellTableViewController : UITableViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) viewDidLoad;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_UIContainerCell : UITableViewCell {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) layoutSubviews;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_UIContainerView : UIView {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) willMoveToSuperview:(UIView *)p0;
	-(void) layoutSubviews;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_CheckBoxRenderer : Xamarin_Forms_Platform_iOS_CheckBoxRendererBase_1 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_CarouselViewLayout : Xamarin_Forms_Platform_iOS_ItemsViewLayout {
}
	-(void) prepareForCollectionViewUpdates:(NSArray *)p0;
	-(void) finalizeCollectionViewUpdates;
@end

@interface Xamarin_Forms_Platform_iOS_CarouselViewController : Xamarin_Forms_Platform_iOS_ItemsViewController_1 {
}
	-(UICollectionViewCell *) collectionView:(UICollectionView *)p0 cellForItemAtIndexPath:(NSIndexPath *)p1;
	-(NSInteger) collectionView:(UICollectionView *)p0 numberOfItemsInSection:(NSInteger)p1;
	-(void) viewDidLoad;
	-(void) viewWillLayoutSubviews;
	-(void) viewDidLayoutSubviews;
	-(void) scrollViewWillBeginDragging:(UIScrollView *)p0;
	-(void) scrollViewDidEndDragging:(UIScrollView *)p0 willDecelerate:(BOOL)p1;
@end

@interface Xamarin_Forms_Platform_iOS_CarouselTemplatedCell : Xamarin_Forms_Platform_iOS_TemplatedCell {
}
	-(id) initWithFrame:(CGRect)p0;
@end

@interface Xamarin_Forms_Platform_iOS_RefreshViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_IndicatorViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ShapeRenderer_2 : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ShapeView : UIView {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ShapeLayer : CALayer {
}
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) drawInContext:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_PathRenderer : Xamarin_Forms_Platform_iOS_ShapeRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_PathView : Xamarin_Forms_Platform_iOS_ShapeView {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_EllipseRenderer : Xamarin_Forms_Platform_iOS_ShapeRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_EllipseView : Xamarin_Forms_Platform_iOS_ShapeView {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_LineRenderer : Xamarin_Forms_Platform_iOS_ShapeRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_LineView : Xamarin_Forms_Platform_iOS_ShapeView {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_PolygonRenderer : Xamarin_Forms_Platform_iOS_ShapeRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_PolygonView : Xamarin_Forms_Platform_iOS_ShapeView {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_PolylineRenderer : Xamarin_Forms_Platform_iOS_ShapeRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_PolylineView : Xamarin_Forms_Platform_iOS_ShapeView {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_RectangleRenderer : Xamarin_Forms_Platform_iOS_ShapeRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_RectangleView : Xamarin_Forms_Platform_iOS_ShapeView {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_EntryCellRenderer_EntryCellTableViewCell : Xamarin_Forms_Platform_iOS_CellTableViewCell {
}
	-(void) layoutSubviews;
@end

@interface Xamarin_Forms_Platform_iOS_CarouselPageRenderer : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) didRotateFromInterfaceOrientation:(NSInteger)p0;
	-(void) viewDidAppear:(BOOL)p0;
	-(void) viewDidDisappear:(BOOL)p0;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidLoad;
	-(void) viewDidUnload;
	-(void) willRotateToInterfaceOrientation:(NSInteger)p0 duration:(double)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_FrameRenderer : Xamarin_Forms_Platform_iOS_VisualElementRenderer_1 {
}
	-(void) addSubview:(UIView *)p0;
	-(void) traitCollectionDidChange:(UITraitCollection *)p0;
	-(void) layoutSubviews;
	-(void) drawRect:(CGRect)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ImageRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_LabelRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) layoutSubviews;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ListViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) layoutSubviews;
	-(void) traitCollectionDidChange:(UITraitCollection *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_TabbedRenderer : UITabBarController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIViewController *) selectedViewController;
	-(void) setSelectedViewController:(UIViewController *)p0;
	-(void) didRotateFromInterfaceOrientation:(NSInteger)p0;
	-(void) viewDidAppear:(BOOL)p0;
	-(void) viewDidDisappear:(BOOL)p0;
	-(void) viewDidLayoutSubviews;
	-(UIViewController *) childViewControllerForStatusBarHidden;
	-(UIViewController *) childViewControllerForHomeIndicatorAutoHidden;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_EventedViewController_FlyoutView : UIView {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) layoutSubviews;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ShellFlyoutContentRenderer : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) viewWillLayoutSubviews;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidLoad;
	-(void) viewWillAppear:(BOOL)p0;
	-(void) viewWillDisappear:(BOOL)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_ShellFlyoutRenderer : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIViewController *) childViewControllerForStatusBarStyle;
	-(void) viewDidLayoutSubviews;
	-(void) viewWillAppear:(BOOL)p0;
	-(void) viewDidLoad;
	-(NSArray *) keyCommands;
	-(void) tabForward:(UIKeyCommand *)p0;
	-(void) tabBackward:(UIKeyCommand *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ShellPageRendererTracker_TitleViewContainer : Xamarin_Forms_Platform_iOS_UIContainerView {
}
	-(CGRect) frame;
	-(void) setFrame:(CGRect)p0;
	-(void) willMoveToSuperview:(UIView *)p0;
	-(CGSize) intrinsicContentSize;
	-(CGSize) sizeThatFits:(CGSize)p0;
@end

@interface Xamarin_Forms_Platform_iOS_ShellRenderer : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidLoad;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ShellSectionRootHeader_ShellSectionHeaderCell : UICollectionViewCell {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) isSelected;
	-(void) setSelected:(BOOL)p0;
	-(void) layoutSubviews;
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
	-(id) initWithFrame:(CGRect)p0;
@end

@interface Xamarin_Forms_Platform_iOS_ShellSectionRootHeader : UICollectionViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) collectionView:(UICollectionView *)p0 canMoveItemAtIndexPath:(NSIndexPath *)p1;
	-(UICollectionViewCell *) collectionView:(UICollectionView *)p0 cellForItemAtIndexPath:(NSIndexPath *)p1;
	-(NSInteger) collectionView:(UICollectionView *)p0 numberOfItemsInSection:(NSInteger)p1;
	-(void) collectionView:(UICollectionView *)p0 didDeselectItemAtIndexPath:(NSIndexPath *)p1;
	-(void) collectionView:(UICollectionView *)p0 didSelectItemAtIndexPath:(NSIndexPath *)p1;
	-(NSInteger) numberOfSectionsInCollectionView:(UICollectionView *)p0;
	-(BOOL) collectionView:(UICollectionView *)p0 shouldSelectItemAtIndexPath:(NSIndexPath *)p1;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidLoad;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_ShellSectionRootRenderer : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidLoad;
	-(void) viewWillAppear:(BOOL)p0;
	-(void) viewSafeAreaInsetsDidChange;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_ShellSectionRenderer : UINavigationController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) navigationBar:(UINavigationBar *)p0 shouldPopItem:(UINavigationItem *)p1;
	-(void) viewWillAppear:(BOOL)p0;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidLoad;
	-(NSArray *) popToRootViewControllerAnimated:(BOOL)p0;
	-(NSArray *) viewControllers;
	-(void) setViewControllers:(NSArray *)p0;
	-(NSArray *) popToViewController:(UIViewController *)p0 animated:(BOOL)p1;
	-(void) pushViewController:(UIViewController *)p0 animated:(BOOL)p1;
	-(UIViewController *) popViewControllerAnimated:(BOOL)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_ShellTableViewSource : NSObject<UIScrollViewDelegate> {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(CGFloat) tableView:(UITableView *)p0 heightForRowAtIndexPath:(NSIndexPath *)p1;
	-(UITableViewCell *) tableView:(UITableView *)p0 cellForRowAtIndexPath:(NSIndexPath *)p1;
	-(CGFloat) tableView:(UITableView *)p0 heightForFooterInSection:(NSInteger)p1;
	-(UIView *) tableView:(UITableView *)p0 viewForFooterInSection:(NSInteger)p1;
	-(NSInteger) numberOfSectionsInTableView:(UITableView *)p0;
	-(void) tableView:(UITableView *)p0 didSelectRowAtIndexPath:(NSIndexPath *)p1;
	-(NSInteger) tableView:(UITableView *)p0 numberOfRowsInSection:(NSInteger)p1;
	-(void) scrollViewDidScroll:(UIScrollView *)p0;
	-(void) tableView:(UITableView *)p0 willDisplayCell:(UITableViewCell *)p1 forRowAtIndexPath:(NSIndexPath *)p2;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface Xamarin_Forms_Platform_iOS_ImageButtonRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(CGSize) sizeThatFits:(CGSize)p0;
	-(id) init;
@end

@interface Xamarin_Forms_Platform_iOS_SwipeViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) willMoveToWindow:(UIWindow *)p0;
	-(void) layoutSubviews;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(UIView *) hitTest:(CGPoint)p0 withEvent:(UIEvent *)p1;
	-(id) init;
@end

@protocol FIRMessagingDelegate
	@optional -(void) messaging:(id)p0 didReceiveRegistrationToken:(NSString *)p1;
	@optional -(void) messaging:(id)p0 didReceiveMessage:(id)p1;
@end

@interface Plugin_FirebasePushNotification_FirebasePushNotificationManager : NSObject<UNUserNotificationCenterDelegate, FIRMessagingDelegate> {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) userNotificationCenter:(UNUserNotificationCenter *)p0 willPresentNotification:(UNNotification *)p1 withCompletionHandler:(void (^)(void *))p2;
	-(void) userNotificationCenter:(UNUserNotificationCenter *)p0 didReceiveNotificationResponse:(UNNotificationResponse *)p1 withCompletionHandler:(void (^)())p2;
	-(void) messaging:(id)p0 didReceiveRegistrationToken:(NSString *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface FIRMessagingMessageInfo : NSObject {
}
	-(NSInteger) status;
	-(id) init;
@end

@interface ApiDefinition__Firebase_CloudMessaging_MessagingDelegate : NSObject<FIRMessagingDelegate> {
}
	-(id) init;
@end

@interface FIRMessagingExtensionHelper : NSObject {
}
	-(void) populateNotificationContent:(UNMutableNotificationContent *)p0 withContentHandler:(void (^)(void *))p1;
	-(id) init;
@end

@interface FIRMessagingRemoteMessage : NSObject {
}
	-(NSDictionary *) appData;
	-(NSString *) messageID;
@end

@interface FIRMessaging : NSObject {
}
	-(id) appDidReceiveMessage:(NSDictionary *)p0;
	-(void) deleteFCMTokenForSenderID:(NSString *)p0 completion:(void (^)(id))p1;
	-(void) retrieveFCMTokenForSenderID:(NSString *)p0 completion:(void (^)(NSString *, id))p1;
	-(void) sendMessage:(NSDictionary *)p0 to:(NSString *)p1 withMessageID:(NSString *)p2 timeToLive:(long long)p3;
	-(void) setAPNSToken:(NSData *)p0 type:(NSInteger)p1;
	-(void) subscribeToTopic:(NSString *)p0;
	-(void) subscribeToTopic:(NSString *)p0 completion:(void (^)(id))p1;
	-(void) unsubscribeFromTopic:(NSString *)p0;
	-(void) unsubscribeFromTopic:(NSString *)p0 completion:(void (^)(id))p1;
	-(NSData *) APNSToken;
	-(void) setAPNSToken:(NSData *)p0;
	-(BOOL) isAutoInitEnabled;
	-(void) setAutoInitEnabled:(BOOL)p0;
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(NSString *) FCMToken;
	-(BOOL) isDirectChannelEstablished;
	-(BOOL) shouldEstablishDirectChannel;
	-(void) setShouldEstablishDirectChannel:(BOOL)p0;
@end

@interface FIRApp : NSObject {
}
	-(void) deleteApp:(void (^)(BOOL))p0;
	-(BOOL) isDataCollectionDefaultEnabled;
	-(void) setDataCollectionDefaultEnabled:(BOOL)p0;
	-(NSString *) name;
	-(id) options;
@end

@interface FIRConfiguration : NSObject {
}
	-(void) setLoggerLevel:(NSInteger)p0;
@end

@interface FIROptions : NSObject {
}
	-(NSObject *) copyWithZone:(id)p0;
	-(NSString *) androidClientID;
	-(void) setAndroidClientID:(NSString *)p0;
	-(NSString *) APIKey;
	-(void) setAPIKey:(NSString *)p0;
	-(NSString *) appGroupID;
	-(void) setAppGroupID:(NSString *)p0;
	-(NSString *) bundleID;
	-(void) setBundleID:(NSString *)p0;
	-(NSString *) clientID;
	-(void) setClientID:(NSString *)p0;
	-(NSString *) databaseURL;
	-(void) setDatabaseURL:(NSString *)p0;
	-(NSString *) deepLinkURLScheme;
	-(void) setDeepLinkURLScheme:(NSString *)p0;
	-(NSString *) GCMSenderID;
	-(void) setGCMSenderID:(NSString *)p0;
	-(NSString *) googleAppID;
	-(void) setGoogleAppID:(NSString *)p0;
	-(NSString *) projectID;
	-(void) setProjectID:(NSString *)p0;
	-(NSString *) storageBucket;
	-(void) setStorageBucket:(NSString *)p0;
	-(NSString *) trackingID;
	-(void) setTrackingID:(NSString *)p0;
	-(id) initWithContentsOfFile:(NSString *)p0;
	-(id) initWithGoogleAppID:(NSString *)p0 GCMSenderID:(NSString *)p1;
@end

@interface FIRInstallationsAuthTokenResult : NSObject {
}
	-(NSString *) authToken;
	-(NSDate *) expirationDate;
	-(id) init;
@end

@interface FIRInstallations : NSObject {
}
	-(void) deleteWithCompletion:(void (^)(void *))p0;
	-(void) authTokenWithCompletion:(void (^)(id, id))p0;
	-(void) authTokenForcingRefresh:(BOOL)p0 completion:(void (^)(id, id))p1;
	-(void) installationIDWithCompletion:(void (^)(NSString *, id))p0;
@end

@interface FIRInstanceIDResult : NSObject {
}
	-(NSObject *) copyWithZone:(id)p0;
	-(NSString *) instanceID;
	-(NSString *) token;
	-(id) init;
@end

@interface FIRInstanceID : NSObject {
}
	-(void) deleteIDWithHandler:(void (^)(id))p0;
	-(void) deleteTokenWithAuthorizedEntity:(NSString *)p0 scope:(NSString *)p1 handler:(void (^)(id))p2;
	-(void) getIDWithHandler:(void (^)(NSString *, id))p0;
	-(void) instanceIDWithHandler:(void (^)(id, id))p0;
	-(void) tokenWithAuthorizedEntity:(NSString *)p0 scope:(NSString *)p1 options:(NSDictionary *)p2 handler:(void (^)(NSString *, id))p3;
@end

@interface OpenTK_Platform_iPhoneOS_iPhoneOSGameView : UIView {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	+(Class) layerClass;
	-(void) layoutSubviews;
	-(void) willMoveToWindow:(UIWindow *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) initWithCoder:(NSCoder *)p0;
	-(id) initWithFrame:(CGRect)p0;
@end

@interface Xamarin_Forms_PancakeView_iOS_PancakeViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) layoutSubviews;
	-(void) drawRect:(CGRect)p0;
	-(id) init;
@end

@interface Xamarin_CommunityToolkit_iOS_UI_Views_SideMenuViewRenderer : Xamarin_Forms_Platform_iOS_VisualElementRenderer_1 {
}
	-(void) addGestureRecognizer:(UIGestureRecognizer *)p0;
	-(id) init;
@end

@interface Xamarin_CommunityToolkit_iOS_Effects_ShouldRecognizeSimultaneouslyRecognizerDelegate : NSObject<UIGestureRecognizerDelegate> {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) gestureRecognizer:(UIGestureRecognizer *)p0 shouldRecognizeSimultaneouslyWithGestureRecognizer:(UIGestureRecognizer *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_CommunityToolkit_UI_Views_MediaElementRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_CommunityToolkit_UI_Views_SemanticOrderViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer {
}
	-(id) init;
@end

@interface Xamarin_CommunityToolkit_UI_Views_ImageSwitcherRenderer : Xamarin_Forms_Platform_iOS_ImageRenderer {
}
	-(id) init;
@end

@interface Xamarin_CommunityToolkit_UI_Views_TextSwitcherRenderer : Xamarin_Forms_Platform_iOS_LabelRenderer {
}
	-(id) init;
@end

@interface Xamarin_CommunityToolkit_UI_Views_CameraViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Xamarin_CommunityToolkit_UI_Views_FormsCameraView : UIView<AVCaptureFileOutputRecordingDelegate> {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) drawRect:(CGRect)p0;
	-(void) captureOutput:(AVCaptureFileOutput *)p0 didFinishRecordingToOutputFileAtURL:(NSURL *)p1 fromConnections:(NSArray *)p2 error:(NSError *)p3;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Xamarin_CommunityToolkit_UI_Views_DrawingViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesMoved:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) drawRect:(CGRect)p0;
	-(id) init;
@end

@interface Xamarin_CommunityToolkit_UI_Views_PopupRenderer : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) viewDidLayoutSubviews;
	-(void) viewDidAppear:(BOOL)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface ImageCircle_Forms_Plugin_iOS_ImageCircleRenderer : Xamarin_Forms_Platform_iOS_ImageRenderer {
}
	-(id) init;
@end

@interface XamSvg_XamForms_iOS_SvgImageRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(id) init;
@end

@interface UISvgImageView : UIImageView {
}
	@property (nonatomic, assign) CGFloat FillWidth;
	@property (nonatomic, assign) CGFloat FillHeight;
	@property (nonatomic, assign) NSString * BundleName;
	@property (nonatomic, assign) NSString * Svg;
	@property (nonatomic, assign) NSString * ColorMapping;
	@property (nonatomic, assign) NSString * ColorMappingSelected;
	@property (nonatomic, assign) int FillMode;
	@property (nonatomic, assign) int AlignmentMode;
	@property (nonatomic, assign) BOOL IsLoadAsync;
	@property (nonatomic, assign) float Zoom;
	@property (nonatomic, assign) BOOL ClearImageWhenUpdating;
	@property (nonatomic, assign) BOOL TraceEnabled;
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(CGFloat) FillWidth;
	-(void) setFillWidth:(CGFloat)p0;
	-(CGFloat) FillHeight;
	-(void) setFillHeight:(CGFloat)p0;
	-(NSString *) BundleName;
	-(void) setBundleName:(NSString *)p0;
	-(NSString *) Svg;
	-(void) setSvg:(NSString *)p0;
	-(NSString *) ColorMapping;
	-(void) setColorMapping:(NSString *)p0;
	-(NSString *) ColorMappingSelected;
	-(void) setColorMappingSelected:(NSString *)p0;
	-(int) FillMode;
	-(void) setFillMode:(int)p0;
	-(int) AlignmentMode;
	-(void) setAlignmentMode:(int)p0;
	-(BOOL) IsLoadAsync;
	-(void) setIsLoadAsync:(BOOL)p0;
	-(float) Zoom;
	-(void) setZoom:(float)p0;
	-(BOOL) ClearImageWhenUpdating;
	-(void) setClearImageWhenUpdating:(BOOL)p0;
	-(BOOL) TraceEnabled;
	-(void) setTraceEnabled:(BOOL)p0;
	-(BOOL) translatesAutoresizingMaskIntoConstraints;
	-(void) setTranslatesAutoresizingMaskIntoConstraints:(BOOL)p0;
	-(CGSize) systemLayoutSizeFittingSize:(CGSize)p0 withHorizontalFittingPriority:(float)p1 verticalFittingPriority:(float)p2;
	-(CGSize) intrinsicContentSize;
	-(void) layoutSubviews;
	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
@end

@interface AiForms_Effects_iOS_TouchEffectGestureRecognizer : UIGestureRecognizer {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesMoved:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface AiForms_Effects_iOS_AlwaysSimultaneouslyGestureRecognizerDelegate : NSObject<UIGestureRecognizerDelegate> {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) gestureRecognizer:(UIGestureRecognizer *)p0 shouldRecognizeSimultaneouslyWithGestureRecognizer:(UIGestureRecognizer *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface IQKeyboardManager : NSObject {
}
	-(BOOL) goNext;
	-(BOOL) goPrevious;
	-(void) registerAllNotifications;
	-(void) registerTextFieldViewClass:(Class)p0 didBeginEditingNotificationName:(NSString *)p1 didEndEditingNotificationName:(NSString *)p2;
	-(void) reloadInputViews;
	-(void) reloadLayoutIfNeeded;
	-(BOOL) resignFirstResponder;
	-(void) unregisterAllNotifications;
	-(void) unregisterTextFieldViewClass:(Class)p0 didBeginEditingNotificationName:(NSString *)p1 didEndEditingNotificationName:(NSString *)p2;
	-(BOOL) canGoNext;
	-(BOOL) canGoPrevious;
	-(NSMutableSet <Class>*) disabledDistanceHandlingClasses;
	-(NSMutableSet <Class>*) disabledToolbarClasses;
	-(NSMutableSet <Class>*) disabledTouchResignedClasses;
	-(BOOL) isEnabled;
	-(void) setEnable:(BOOL)p0;
	-(BOOL) isEnableAutoToolbar;
	-(void) setEnableAutoToolbar:(BOOL)p0;
	-(BOOL) enableDebugging;
	-(void) setEnableDebugging:(BOOL)p0;
	-(NSMutableSet <Class>*) enabledDistanceHandlingClasses;
	-(NSMutableSet <Class>*) enabledToolbarClasses;
	-(NSMutableSet <Class>*) enabledTouchResignedClasses;
	-(NSInteger) keyboardAppearance;
	-(void) setKeyboardAppearance:(NSInteger)p0;
	-(CGFloat) keyboardDistanceFromTextField;
	-(void) setKeyboardDistanceFromTextField:(CGFloat)p0;
	-(BOOL) isKeyboardShowing;
	-(BOOL) layoutIfNeededOnUpdate;
	-(void) setLayoutIfNeededOnUpdate:(BOOL)p0;
	-(CGFloat) movedDistance;
	-(BOOL) overrideKeyboardAppearance;
	-(void) setOverrideKeyboardAppearance:(BOOL)p0;
	-(UIFont *) placeholderFont;
	-(void) setPlaceholderFont:(UIFont *)p0;
	-(BOOL) preventShowingBottomBlankSpace;
	-(void) setPreventShowingBottomBlankSpace:(BOOL)p0;
	-(NSInteger) previousNextDisplayMode;
	-(void) setPreviousNextDisplayMode:(NSInteger)p0;
	-(UITapGestureRecognizer *) resignFirstResponderGesture;
	-(BOOL) shouldFixInteractivePopGestureRecognizer;
	-(void) setShouldFixInteractivePopGestureRecognizer:(BOOL)p0;
	-(BOOL) shouldPlayInputClicks;
	-(void) setShouldPlayInputClicks:(BOOL)p0;
	-(BOOL) shouldResignOnTouchOutside;
	-(void) setShouldResignOnTouchOutside:(BOOL)p0;
	-(BOOL) shouldShowTextFieldPlaceholder;
	-(void) setShouldShowTextFieldPlaceholder:(BOOL)p0;
	-(BOOL) shouldShowToolbarPlaceholder;
	-(void) setShouldShowToolbarPlaceholder:(BOOL)p0;
	-(BOOL) shouldToolbarUsesTextFieldTintColor;
	-(void) setShouldToolbarUsesTextFieldTintColor:(BOOL)p0;
	-(UIColor *) toolbarBarTintColor;
	-(void) setToolbarBarTintColor:(UIColor *)p0;
	-(UIImage *) toolbarDoneBarButtonItemImage;
	-(void) setToolbarDoneBarButtonItemImage:(UIImage *)p0;
	-(NSString *) toolbarDoneBarButtonItemText;
	-(void) setToolbarDoneBarButtonItemText:(NSString *)p0;
	-(NSInteger) toolbarManageBehaviour;
	-(void) setToolbarManageBehaviour:(NSInteger)p0;
	-(NSMutableSet <Class>*) toolbarPreviousNextAllowedClasses;
	-(UIColor *) toolbarTintColor;
	-(void) setToolbarTintColor:(UIColor *)p0;
	-(NSMutableSet <Class>*) touchResignedGestureIgnoreClasses;
@end

@interface IQKeyboardReturnKeyHandler : NSObject {
}
	-(void) addResponderFromView:(UIView *)p0;
	-(void) addTextFieldView:(UIView *)p0;
	-(void) removeResponderFromView:(UIView *)p0;
	-(void) removeTextFieldView:(UIView *)p0;
	-(NSInteger) lastTextFieldReturnKeyType;
	-(void) setLastTextFieldReturnKeyType:(NSInteger)p0;
	-(NSObject *) delegate;
	-(void) setDelegate:(NSObject *)p0;
	-(id) init;
	-(id) initWithViewController:(UIViewController *)p0;
@end

@protocol UIView_IQToolbarAddition
	@optional @property (nonatomic, assign, readonly) id keyboardToolbar;
	@optional @property (nonatomic, assign) BOOL shouldHideToolbarPlaceholder;
	@optional @property (nonatomic, assign) BOOL shouldHidePlaceholderText;
	@optional @property (nonatomic, retain) NSString * toolbarPlaceholder;
	@optional @property (nonatomic, retain) NSString * placeholderText;
	@optional @property (nonatomic, retain, readonly) NSString * drawingToolbarPlaceholder;
	@optional @property (nonatomic, retain, readonly) NSString * drawingPlaceholderText;
	@optional -(void) addDoneOnKeyboardWithTarget:(NSObject *)p0 action:(SEL)p1;
	@optional -(void) addDoneOnKeyboardWithTarget:(NSObject *)p0 action:(SEL)p1 titleText:(NSString *)p2;
	@optional -(void) addDoneOnKeyboardWithTarget:(NSObject *)p0 action:(SEL)p1 shouldShowPlaceholder:(BOOL)p2;
	@optional -(void) addRightButtonOnKeyboardWithText:(NSString *)p0 target:(NSObject *)p1 action:(SEL)p2;
	@optional -(void) addRightButtonOnKeyboardWithText:(NSString *)p0 target:(NSObject *)p1 action:(SEL)p2 titleText:(NSString *)p3;
	@optional -(void) addRightButtonOnKeyboardWithText:(NSString *)p0 target:(NSObject *)p1 action:(SEL)p2 shouldShowPlaceholder:(BOOL)p3;
	@optional -(void) addRightButtonOnKeyboardWithImage:(UIImage *)p0 target:(NSObject *)p1 action:(SEL)p2 shouldShowPlaceholder:(BOOL)p3;
	@optional -(void) addRightButtonOnKeyboardWithImage:(UIImage *)p0 target:(NSObject *)p1 action:(SEL)p2 titleText:(NSString *)p3;
	@optional -(void) addCancelDoneOnKeyboardWithTarget:(NSObject *)p0 cancelAction:(SEL)p1 doneAction:(SEL)p2;
	@optional -(void) addCancelDoneOnKeyboardWithTarget:(NSObject *)p0 cancelAction:(SEL)p1 doneAction:(SEL)p2 titleText:(NSString *)p3;
	@optional -(void) addCancelDoneOnKeyboardWithTarget:(NSObject *)p0 cancelAction:(SEL)p1 doneAction:(SEL)p2 shouldShowPlaceholder:(BOOL)p3;
	@optional -(void) addLeftRightOnKeyboardWithTarget:(NSObject *)p0 leftButtonTitle:(NSString *)p1 rightButtonTitle:(NSString *)p2 leftButtonAction:(SEL)p3 rightButtonAction:(SEL)p4;
	@optional -(void) addLeftRightOnKeyboardWithTarget:(NSObject *)p0 leftButtonTitle:(NSString *)p1 rightButtonTitle:(NSString *)p2 leftButtonAction:(SEL)p3 rightButtonAction:(SEL)p4 titleText:(NSString *)p5;
	@optional -(void) addLeftRightOnKeyboardWithTarget:(NSObject *)p0 leftButtonTitle:(NSString *)p1 rightButtonTitle:(NSString *)p2 leftButtonAction:(SEL)p3 rightButtonAction:(SEL)p4 shouldShowPlaceholder:(BOOL)p5;
	@optional -(void) addPreviousNextDoneOnKeyboardWithTarget:(NSObject *)p0 previousAction:(SEL)p1 nextAction:(SEL)p2 doneAction:(SEL)p3;
	@optional -(void) addPreviousNextDoneOnKeyboardWithTarget:(NSObject *)p0 previousAction:(SEL)p1 nextAction:(SEL)p2 doneAction:(SEL)p3 titleText:(NSString *)p4;
	@optional -(void) addPreviousNextDoneOnKeyboardWithTarget:(NSObject *)p0 previousAction:(SEL)p1 nextAction:(SEL)p2 doneAction:(SEL)p3 shouldShowPlaceholder:(BOOL)p4;
	@optional -(void) addPreviousNextRightOnKeyboardWithTarget:(NSObject *)p0 rightButtonTitle:(NSString *)p1 previousAction:(SEL)p2 nextAction:(SEL)p3 rightButtonAction:(SEL)p4;
	@optional -(void) addPreviousNextRightOnKeyboardWithTarget:(NSObject *)p0 rightButtonTitle:(NSString *)p1 previousAction:(SEL)p2 nextAction:(SEL)p3 rightButtonAction:(SEL)p4 titleText:(NSString *)p5;
	@optional -(void) addPreviousNextRightOnKeyboardWithTarget:(NSObject *)p0 rightButtonTitle:(NSString *)p1 previousAction:(SEL)p2 nextAction:(SEL)p3 rightButtonAction:(SEL)p4 shouldShowPlaceholder:(BOOL)p5;
	@optional -(void) addPreviousNextRightOnKeyboardWithTarget:(NSObject *)p0 rightButtonImage:(UIImage *)p1 previousAction:(SEL)p2 nextAction:(SEL)p3 rightButtonAction:(SEL)p4 titleText:(NSString *)p5;
	@optional -(void) addPreviousNextRightOnKeyboardWithTarget:(NSObject *)p0 rightButtonImage:(UIImage *)p1 previousAction:(SEL)p2 nextAction:(SEL)p3 rightButtonAction:(SEL)p4 shouldShowPlaceholder:(BOOL)p5;
@end

@interface Xamarin_IQBarButtonItem_IQBarButtonItemAppearance : UIKit_UIBarButtonItem_UIBarButtonItemAppearance {
}
@end

@interface IQBarButtonItem : UIBarButtonItem {
}
	-(void) setTarget:(NSObject *)p0 action:(SEL)p1;
	-(NSInvocation *) invocation;
	-(void) setInvocation:(NSInvocation *)p0;
	-(BOOL) isSystemItem;
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
@end

@interface Xamarin_IQPreviousNextView_IQPreviousNextViewAppearance : UIKit_UIView_UIViewAppearance {
}
@end

@interface IQPreviousNextView : UIView {
}
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
@end

@interface Xamarin_IQTextView_IQTextViewAppearance : UIKit_UITextView_UITextViewAppearance {
}
@end

@interface IQTextView : UITextView {
}
	-(NSString *) placeholder;
	-(void) setPlaceholder:(NSString *)p0;
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
@end

@interface Xamarin_IQTitleBarButtonItem_IQTitleBarButtonItemAppearance : Xamarin_IQBarButtonItem_IQBarButtonItemAppearance {
}
@end

@interface IQTitleBarButtonItem : IQBarButtonItem {
}
	-(UIColor *) selectableTextColor;
	-(void) setSelectableTextColor:(UIColor *)p0;
	-(UIFont *) titleFont;
	-(void) setTitleFont:(UIFont *)p0;
	-(id) initWithCoder:(NSCoder *)p0;
	-(id) initWithTitle:(NSString *)p0;
@end

@interface Xamarin_IQToolbar_IQToolbarAppearance : UIKit_UIToolbar_UIToolbarAppearance {
}
@end

@interface IQToolbar : UIToolbar {
}
	-(id) doneBarButton;
	-(void) setDoneBarButton:(id)p0;
	-(BOOL) enableInputClicksWhenVisible;
	-(id) nextBarButton;
	-(void) setNextBarButton:(id)p0;
	-(id) previousBarButton;
	-(void) setPreviousBarButton:(id)p0;
	-(id) titleBarButton;
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
@end

@interface Xamarin_UIView_IQToolbarAddition_UIView_IQToolbarAdditionAppearance : UIKit_UIView_UIViewAppearance {
}
@end

@interface Syncfusion_SfPdfViewer_XForms_iOS_SfPdfDocumentViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface SfBusyIndicator : UIControl {
}
	@property (nonatomic, assign) int AnimationType;
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(int) AnimationType;
	-(void) setAnimationType:(int)p0;
	-(void) awakeFromNib;
	-(void) drawRect:(CGRect)p0;
	-(void) layoutSubviews;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Syncfusion_SfBusyIndicator_iOS_SFBusyIndicator : SfBusyIndicator {
}
	-(id) init;
@end

@interface Syncfusion_XForms_iOS_Graphics_SfGradientViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer {
}
	-(void) layoutSubviews;
	-(void) drawRect:(CGRect)p0;
	-(id) init;
@end

@interface Syncfusion_XForms_iOS_Shimmer_SfShimmerRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer {
}
	-(CGRect) frame;
	-(void) setFrame:(CGRect)p0;
	-(void) layoutSubviews;
	-(id) init;
@end

@interface Syncfusion_XForms_iOS_TextInputLayout_SfTextInputLayoutRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(id) init;
@end

@interface Syncfusion_XForms_iOS_TextInputLayout_InputLayoutClearButtonViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) layoutSubviews;
	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(id) init;
@end

@interface Syncfusion_XForms_iOS_Border_SfBorderRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer {
}
	-(void) drawRect:(CGRect)p0;
	-(id) init;
@end

@interface Syncfusion_XForms_iOS_EffectsView_SfEffectsViewRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer {
}
	-(CGRect) frame;
	-(void) setFrame:(CGRect)p0;
	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesMoved:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_XForms_iOS_SfRangeSliderRenderer : Xamarin_Forms_Platform_iOS_ViewRenderer_2 {
}
	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesMoved:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_iOS_SfLabelItems : NSObject {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_iOS_SFLabelItems : Syncfusion_SfRangeSlider_iOS_SfLabelItems {
}
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_iOS_SfRangeKnobLayer : CALayer {
}
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) layoutSublayers;
	-(void) drawInContext:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface SfRangeSlider : UIView {
}
	@property (nonatomic, assign) CGFloat Maximum;
	@property (nonatomic, assign) CGFloat Minimum;
	@property (nonatomic, assign) CGFloat TickLength;
	@property (nonatomic, assign) CGFloat Value;
	@property (nonatomic, assign) CGFloat RangeStart;
	@property (nonatomic, assign) CGFloat RangeEnd;
	@property (nonatomic, assign) CGFloat TickFrequency;
	@property (nonatomic, assign) UIColor * LabelColor;
	@property (nonatomic, assign) UIColor * ThumbBorderColor;
	@property (nonatomic, assign) double TrackCornerRadius;
	@property (nonatomic, assign) CGFloat ThumbBorderThickness;
	@property (nonatomic, assign) UIColor * TrackColor;
	@property (nonatomic, assign) NSString * LabelFormat;
	@property (nonatomic, assign) CGFloat TrackThickness;
	@property (nonatomic, assign) CGFloat TrackSelectionThickness;
	@property (nonatomic, assign) UIColor * TrackSelectionColor;
	@property (nonatomic, assign) UIColor * KnobColor;
	@property (nonatomic, assign) BOOL ShowRange;
	@property (nonatomic, assign) BOOL ShowValueLabel;
	@property (nonatomic, assign) BOOL IsDirectionalReversed;
	@property (nonatomic, assign) int Orientation;
	@property (nonatomic, assign) int TickPlacement;
	@property (nonatomic, assign) int ValuePlacement;
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(CGFloat) Maximum;
	-(void) setMaximum:(CGFloat)p0;
	-(CGFloat) Minimum;
	-(void) setMinimum:(CGFloat)p0;
	-(CGFloat) TickLength;
	-(void) setTickLength:(CGFloat)p0;
	-(CGFloat) Value;
	-(void) setValue:(CGFloat)p0;
	-(CGFloat) RangeStart;
	-(void) setRangeStart:(CGFloat)p0;
	-(CGFloat) RangeEnd;
	-(void) setRangeEnd:(CGFloat)p0;
	-(CGFloat) TickFrequency;
	-(void) setTickFrequency:(CGFloat)p0;
	-(UIColor *) LabelColor;
	-(void) setLabelColor:(UIColor *)p0;
	-(UIColor *) ThumbBorderColor;
	-(void) setThumbBorderColor:(UIColor *)p0;
	-(double) TrackCornerRadius;
	-(void) setTrackCornerRadius:(double)p0;
	-(CGFloat) ThumbBorderThickness;
	-(void) setThumbBorderThickness:(CGFloat)p0;
	-(UIColor *) TrackColor;
	-(void) setTrackColor:(UIColor *)p0;
	-(NSString *) LabelFormat;
	-(void) setLabelFormat:(NSString *)p0;
	-(CGFloat) TrackThickness;
	-(void) setTrackThickness:(CGFloat)p0;
	-(CGFloat) TrackSelectionThickness;
	-(void) setTrackSelectionThickness:(CGFloat)p0;
	-(UIColor *) TrackSelectionColor;
	-(void) setTrackSelectionColor:(UIColor *)p0;
	-(UIColor *) KnobColor;
	-(void) setKnobColor:(UIColor *)p0;
	-(BOOL) ShowRange;
	-(void) setShowRange:(BOOL)p0;
	-(BOOL) ShowValueLabel;
	-(void) setShowValueLabel:(BOOL)p0;
	-(BOOL) IsDirectionalReversed;
	-(void) setIsDirectionalReversed:(BOOL)p0;
	-(int) Orientation;
	-(void) setOrientation:(int)p0;
	-(int) TickPlacement;
	-(void) setTickPlacement:(int)p0;
	-(int) ValuePlacement;
	-(void) setValuePlacement:(int)p0;
	-(CGRect) frame;
	-(void) setFrame:(CGRect)p0;
	-(void) awakeFromNib;
	-(void) drawRect:(CGRect)p0;
	-(void) layoutSubviews;
	-(UIView *) hitTest:(CGPoint)p0 withEvent:(UIEvent *)p1;
	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_iOS_SFRangeSlider : SfRangeSlider {
}
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_iOS_SfRangeTickLayer : CALayer {
}
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) drawInContext:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_iOS_SfRangeTracker : CALayer {
}
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) drawInContext:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_iOS_SfThumb : NSObject {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_iOS_SFThumb : Syncfusion_SfRangeSlider_iOS_SfThumb {
}
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_iOS_SfThumbItem : UIView {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) drawRect:(CGRect)p0 forViewPrintFormatter:(UIViewPrintFormatter *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface Syncfusion_SfRangeSlider_iOS_SFThumbItem : Syncfusion_SfRangeSlider_iOS_SfThumbItem {
}
	-(id) init;
@end

@interface XamForms_Controls_iOS_CalendarButtonRenderer : Xamarin_Forms_Platform_iOS_ButtonRenderer {
}
	-(void) drawRect:(CGRect)p0;
	-(id) init;
@end


