

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.xx.xxxx */
/* at a redacted point in time
 */
/* Compiler settings for ../../edge_embedded_browser/client/win/current/webview2experimental.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.xx.xxxx 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */


#ifndef __webview2experimental_h__
#define __webview2experimental_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

#ifndef DECLSPEC_XFGVIRT
#if _CONTROL_FLOW_GUARD_XFG
#define DECLSPEC_XFGVIRT(base, func) __declspec(xfg_virtual(base, func))
#else
#define DECLSPEC_XFGVIRT(base, func)
#endif
#endif

/* Forward Declarations */ 

#ifndef __ICoreWebView2Experimental5_FWD_DEFINED__
#define __ICoreWebView2Experimental5_FWD_DEFINED__
typedef interface ICoreWebView2Experimental5 ICoreWebView2Experimental5;

#endif 	/* __ICoreWebView2Experimental5_FWD_DEFINED__ */


#ifndef __ICoreWebView2Experimental16_FWD_DEFINED__
#define __ICoreWebView2Experimental16_FWD_DEFINED__
typedef interface ICoreWebView2Experimental16 ICoreWebView2Experimental16;

#endif 	/* __ICoreWebView2Experimental16_FWD_DEFINED__ */


#ifndef __ICoreWebView2Experimental18_FWD_DEFINED__
#define __ICoreWebView2Experimental18_FWD_DEFINED__
typedef interface ICoreWebView2Experimental18 ICoreWebView2Experimental18;

#endif 	/* __ICoreWebView2Experimental18_FWD_DEFINED__ */


#ifndef __ICoreWebView2Experimental19_FWD_DEFINED__
#define __ICoreWebView2Experimental19_FWD_DEFINED__
typedef interface ICoreWebView2Experimental19 ICoreWebView2Experimental19;

#endif 	/* __ICoreWebView2Experimental19_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalCompositionController4_FWD_DEFINED__
#define __ICoreWebView2ExperimentalCompositionController4_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalCompositionController4 ICoreWebView2ExperimentalCompositionController4;

#endif 	/* __ICoreWebView2ExperimentalCompositionController4_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalControllerOptions_FWD_DEFINED__
#define __ICoreWebView2ExperimentalControllerOptions_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalControllerOptions ICoreWebView2ExperimentalControllerOptions;

#endif 	/* __ICoreWebView2ExperimentalControllerOptions_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalEnvironment3_FWD_DEFINED__
#define __ICoreWebView2ExperimentalEnvironment3_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalEnvironment3 ICoreWebView2ExperimentalEnvironment3;

#endif 	/* __ICoreWebView2ExperimentalEnvironment3_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalExecuteScriptResult_FWD_DEFINED__
#define __ICoreWebView2ExperimentalExecuteScriptResult_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalExecuteScriptResult ICoreWebView2ExperimentalExecuteScriptResult;

#endif 	/* __ICoreWebView2ExperimentalExecuteScriptResult_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler_FWD_DEFINED__
#define __ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler;

#endif 	/* __ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalScriptException_FWD_DEFINED__
#define __ICoreWebView2ExperimentalScriptException_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalScriptException ICoreWebView2ExperimentalScriptException;

#endif 	/* __ICoreWebView2ExperimentalScriptException_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalEnvironment10_FWD_DEFINED__
#define __ICoreWebView2ExperimentalEnvironment10_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalEnvironment10 ICoreWebView2ExperimentalEnvironment10;

#endif 	/* __ICoreWebView2ExperimentalEnvironment10_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalFrame4_FWD_DEFINED__
#define __ICoreWebView2ExperimentalFrame4_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalFrame4 ICoreWebView2ExperimentalFrame4;

#endif 	/* __ICoreWebView2ExperimentalFrame4_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler_FWD_DEFINED__
#define __ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler;

#endif 	/* __ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler_FWD_DEFINED__ */


#ifndef __ICoreWebView2PermissionRequestedEventArgs_FWD_DEFINED__
#define __ICoreWebView2PermissionRequestedEventArgs_FWD_DEFINED__
typedef interface ICoreWebView2PermissionRequestedEventArgs ICoreWebView2PermissionRequestedEventArgs;

#endif 	/* __ICoreWebView2PermissionRequestedEventArgs_FWD_DEFINED__ */


#ifndef __ICoreWebView2PermissionRequestedEventArgs2_FWD_DEFINED__
#define __ICoreWebView2PermissionRequestedEventArgs2_FWD_DEFINED__
typedef interface ICoreWebView2PermissionRequestedEventArgs2 ICoreWebView2PermissionRequestedEventArgs2;

#endif 	/* __ICoreWebView2PermissionRequestedEventArgs2_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalPermissionRequestedEventArgs3_FWD_DEFINED__
#define __ICoreWebView2ExperimentalPermissionRequestedEventArgs3_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalPermissionRequestedEventArgs3 ICoreWebView2ExperimentalPermissionRequestedEventArgs3;

#endif 	/* __ICoreWebView2ExperimentalPermissionRequestedEventArgs3_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalPermissionSetting_FWD_DEFINED__
#define __ICoreWebView2ExperimentalPermissionSetting_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalPermissionSetting ICoreWebView2ExperimentalPermissionSetting;

#endif 	/* __ICoreWebView2ExperimentalPermissionSetting_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalPermissionSettingCollectionView_FWD_DEFINED__
#define __ICoreWebView2ExperimentalPermissionSettingCollectionView_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalPermissionSettingCollectionView ICoreWebView2ExperimentalPermissionSettingCollectionView;

#endif 	/* __ICoreWebView2ExperimentalPermissionSettingCollectionView_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalProfile6_FWD_DEFINED__
#define __ICoreWebView2ExperimentalProfile6_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalProfile6 ICoreWebView2ExperimentalProfile6;

#endif 	/* __ICoreWebView2ExperimentalProfile6_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalSetPermissionStateCompletedHandler_FWD_DEFINED__
#define __ICoreWebView2ExperimentalSetPermissionStateCompletedHandler_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalSetPermissionStateCompletedHandler ICoreWebView2ExperimentalSetPermissionStateCompletedHandler;

#endif 	/* __ICoreWebView2ExperimentalSetPermissionStateCompletedHandler_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalSharedBuffer_FWD_DEFINED__
#define __ICoreWebView2ExperimentalSharedBuffer_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalSharedBuffer ICoreWebView2ExperimentalSharedBuffer;

#endif 	/* __ICoreWebView2ExperimentalSharedBuffer_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_FWD_DEFINED__
#define __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler;

#endif 	/* __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalUpdateRuntimeResult_FWD_DEFINED__
#define __ICoreWebView2ExperimentalUpdateRuntimeResult_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalUpdateRuntimeResult ICoreWebView2ExperimentalUpdateRuntimeResult;

#endif 	/* __ICoreWebView2ExperimentalUpdateRuntimeResult_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_FWD_DEFINED__
#define __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalWebResourceRequestedEventArgs ICoreWebView2ExperimentalWebResourceRequestedEventArgs;

#endif 	/* __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalNavigationStartingEventArgs2_FWD_DEFINED__
#define __ICoreWebView2ExperimentalNavigationStartingEventArgs2_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalNavigationStartingEventArgs2 ICoreWebView2ExperimentalNavigationStartingEventArgs2;

#endif 	/* __ICoreWebView2ExperimentalNavigationStartingEventArgs2_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalSettings7_FWD_DEFINED__
#define __ICoreWebView2ExperimentalSettings7_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalSettings7 ICoreWebView2ExperimentalSettings7;

#endif 	/* __ICoreWebView2ExperimentalSettings7_FWD_DEFINED__ */


/* header files for imported files */
#include "webview2.h"

#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __WebView2Experimental_LIBRARY_DEFINED__
#define __WebView2Experimental_LIBRARY_DEFINED__

/* library WebView2Experimental */
/* [version][uuid] */ 

























typedef /* [v1_enum] */ 
enum COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS
    {
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_NONE	= 0,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_DOCUMENT	= 1,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_SHARED_WORKER	= 2,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_SERVICE_WORKER	= 4,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_ALL	= 0xffffffff
    } 	COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS;

DEFINE_ENUM_FLAG_OPERATORS(COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS)
typedef struct COREWEBVIEW2_MATRIX_4X4
    {
    FLOAT _11;
    FLOAT _12;
    FLOAT _13;
    FLOAT _14;
    FLOAT _21;
    FLOAT _22;
    FLOAT _23;
    FLOAT _24;
    FLOAT _31;
    FLOAT _32;
    FLOAT _33;
    FLOAT _34;
    FLOAT _41;
    FLOAT _42;
    FLOAT _43;
    FLOAT _44;
    } 	COREWEBVIEW2_MATRIX_4X4;

typedef /* [v1_enum] */ 
enum COREWEBVIEW2_UPDATE_RUNTIME_STATUS
    {
        COREWEBVIEW2_UPDATE_RUNTIME_STATUS_LATEST_VERSION_INSTALLED	= 0,
        COREWEBVIEW2_UPDATE_RUNTIME_STATUS_UPDATE_ALREADY_RUNNING	= ( COREWEBVIEW2_UPDATE_RUNTIME_STATUS_LATEST_VERSION_INSTALLED + 1 ) ,
        COREWEBVIEW2_UPDATE_RUNTIME_STATUS_BLOCKED_BY_POLICY	= ( COREWEBVIEW2_UPDATE_RUNTIME_STATUS_UPDATE_ALREADY_RUNNING + 1 ) ,
        COREWEBVIEW2_UPDATE_RUNTIME_STATUS_FAILED	= ( COREWEBVIEW2_UPDATE_RUNTIME_STATUS_BLOCKED_BY_POLICY + 1 ) 
    } 	COREWEBVIEW2_UPDATE_RUNTIME_STATUS;

typedef /* [v1_enum] */ 
enum COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL
    {
        COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL_NORMAL	= 0,
        COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL_LOW	= ( COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL_NORMAL + 1 ) 
    } 	COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL;

typedef /* [v1_enum] */ 
enum COREWEBVIEW2_SHARED_BUFFER_ACCESS
    {
        COREWEBVIEW2_SHARED_BUFFER_ACCESS_READ_ONLY	= 0,
        COREWEBVIEW2_SHARED_BUFFER_ACCESS_READ_WRITE	= ( COREWEBVIEW2_SHARED_BUFFER_ACCESS_READ_ONLY + 1 ) 
    } 	COREWEBVIEW2_SHARED_BUFFER_ACCESS;

typedef /* [v1_enum] */ 
enum COREWEBVIEW2_NAVIGATION_KIND
    {
        COREWEBVIEW2_NAVIGATION_KIND_RELOAD	= 0,
        COREWEBVIEW2_NAVIGATION_KIND_BACK_OR_FORWARD	= 1,
        COREWEBVIEW2_NAVIGATION_KIND_NEW_DOCUMENT	= 2
    } 	COREWEBVIEW2_NAVIGATION_KIND;


EXTERN_C const IID LIBID_WebView2Experimental;

#ifndef __ICoreWebView2Experimental5_INTERFACE_DEFINED__
#define __ICoreWebView2Experimental5_INTERFACE_DEFINED__

/* interface ICoreWebView2Experimental5 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2Experimental5 = {0xE05E04CA,0x7924,0x4C04,{0xA8,0x4C,0xA9,0x05,0x72,0xDB,0xA2,0x2A}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("E05E04CA-7924-4C04-A84C-A90572DBA22A")
    ICoreWebView2Experimental5 : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_MemoryUsageTargetLevel( 
            /* [retval][out] */ COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL *level) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_MemoryUsageTargetLevel( 
            /* [in] */ COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL level) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2Experimental5Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2Experimental5 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2Experimental5 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2Experimental5 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2Experimental5, get_MemoryUsageTargetLevel)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_MemoryUsageTargetLevel )( 
            ICoreWebView2Experimental5 * This,
            /* [retval][out] */ COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL *level);
        
        DECLSPEC_XFGVIRT(ICoreWebView2Experimental5, put_MemoryUsageTargetLevel)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_MemoryUsageTargetLevel )( 
            ICoreWebView2Experimental5 * This,
            /* [in] */ COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL level);
        
        END_INTERFACE
    } ICoreWebView2Experimental5Vtbl;

    interface ICoreWebView2Experimental5
    {
        CONST_VTBL struct ICoreWebView2Experimental5Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2Experimental5_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2Experimental5_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2Experimental5_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2Experimental5_get_MemoryUsageTargetLevel(This,level)	\
    ( (This)->lpVtbl -> get_MemoryUsageTargetLevel(This,level) ) 

#define ICoreWebView2Experimental5_put_MemoryUsageTargetLevel(This,level)	\
    ( (This)->lpVtbl -> put_MemoryUsageTargetLevel(This,level) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2Experimental5_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2Experimental16_INTERFACE_DEFINED__
#define __ICoreWebView2Experimental16_INTERFACE_DEFINED__

/* interface ICoreWebView2Experimental16 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2Experimental16 = {0x679ddf3f,0x9044,0x486f,{0x84,0x58,0x16,0x65,0x3a,0x0e,0x16,0x03}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("679ddf3f-9044-486f-8458-16653a0e1603")
    ICoreWebView2Experimental16 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE AddWebResourceRequestedFilterWithRequestSourceKinds( 
            /* [in] */ const LPCWSTR uri,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE RemoveWebResourceRequestedFilterWithRequestSourceKinds( 
            /* [in] */ const LPCWSTR uri,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2Experimental16Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2Experimental16 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2Experimental16 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2Experimental16 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2Experimental16, AddWebResourceRequestedFilterWithRequestSourceKinds)
        HRESULT ( STDMETHODCALLTYPE *AddWebResourceRequestedFilterWithRequestSourceKinds )( 
            ICoreWebView2Experimental16 * This,
            /* [in] */ const LPCWSTR uri,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        
        DECLSPEC_XFGVIRT(ICoreWebView2Experimental16, RemoveWebResourceRequestedFilterWithRequestSourceKinds)
        HRESULT ( STDMETHODCALLTYPE *RemoveWebResourceRequestedFilterWithRequestSourceKinds )( 
            ICoreWebView2Experimental16 * This,
            /* [in] */ const LPCWSTR uri,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        
        END_INTERFACE
    } ICoreWebView2Experimental16Vtbl;

    interface ICoreWebView2Experimental16
    {
        CONST_VTBL struct ICoreWebView2Experimental16Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2Experimental16_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2Experimental16_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2Experimental16_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2Experimental16_AddWebResourceRequestedFilterWithRequestSourceKinds(This,uri,resourceContext,requestSourceKinds)	\
    ( (This)->lpVtbl -> AddWebResourceRequestedFilterWithRequestSourceKinds(This,uri,resourceContext,requestSourceKinds) ) 

#define ICoreWebView2Experimental16_RemoveWebResourceRequestedFilterWithRequestSourceKinds(This,uri,resourceContext,requestSourceKinds)	\
    ( (This)->lpVtbl -> RemoveWebResourceRequestedFilterWithRequestSourceKinds(This,uri,resourceContext,requestSourceKinds) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2Experimental16_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2Experimental18_INTERFACE_DEFINED__
#define __ICoreWebView2Experimental18_INTERFACE_DEFINED__

/* interface ICoreWebView2Experimental18 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2Experimental18 = {0xB96480A2,0x167A,0x469F,{0xA0,0x90,0x5F,0x0F,0x5C,0x88,0xDB,0xE4}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("B96480A2-167A-469F-A090-5F0F5C88DBE4")
    ICoreWebView2Experimental18 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE PostSharedBufferToScript( 
            /* [in] */ ICoreWebView2ExperimentalSharedBuffer *sharedBuffer,
            /* [in] */ COREWEBVIEW2_SHARED_BUFFER_ACCESS access,
            /* [in] */ LPCWSTR additionalDataAsJson) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2Experimental18Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2Experimental18 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2Experimental18 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2Experimental18 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2Experimental18, PostSharedBufferToScript)
        HRESULT ( STDMETHODCALLTYPE *PostSharedBufferToScript )( 
            ICoreWebView2Experimental18 * This,
            /* [in] */ ICoreWebView2ExperimentalSharedBuffer *sharedBuffer,
            /* [in] */ COREWEBVIEW2_SHARED_BUFFER_ACCESS access,
            /* [in] */ LPCWSTR additionalDataAsJson);
        
        END_INTERFACE
    } ICoreWebView2Experimental18Vtbl;

    interface ICoreWebView2Experimental18
    {
        CONST_VTBL struct ICoreWebView2Experimental18Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2Experimental18_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2Experimental18_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2Experimental18_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2Experimental18_PostSharedBufferToScript(This,sharedBuffer,access,additionalDataAsJson)	\
    ( (This)->lpVtbl -> PostSharedBufferToScript(This,sharedBuffer,access,additionalDataAsJson) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2Experimental18_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2Experimental19_INTERFACE_DEFINED__
#define __ICoreWebView2Experimental19_INTERFACE_DEFINED__

/* interface ICoreWebView2Experimental19 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2Experimental19 = {0x4C765E35,0x5BEB,0x4631,{0xB9,0x31,0x5E,0x52,0xD9,0xB0,0xA9,0xBE}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("4C765E35-5BEB-4631-B931-5E52D9B0A9BE")
    ICoreWebView2Experimental19 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE ExecuteScriptWithResult( 
            /* [in] */ LPCWSTR javaScript,
            /* [in] */ ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler *handler) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2Experimental19Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2Experimental19 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2Experimental19 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2Experimental19 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2Experimental19, ExecuteScriptWithResult)
        HRESULT ( STDMETHODCALLTYPE *ExecuteScriptWithResult )( 
            ICoreWebView2Experimental19 * This,
            /* [in] */ LPCWSTR javaScript,
            /* [in] */ ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler *handler);
        
        END_INTERFACE
    } ICoreWebView2Experimental19Vtbl;

    interface ICoreWebView2Experimental19
    {
        CONST_VTBL struct ICoreWebView2Experimental19Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2Experimental19_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2Experimental19_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2Experimental19_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2Experimental19_ExecuteScriptWithResult(This,javaScript,handler)	\
    ( (This)->lpVtbl -> ExecuteScriptWithResult(This,javaScript,handler) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2Experimental19_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalCompositionController4_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalCompositionController4_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalCompositionController4 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalCompositionController4 = {0xe6041d7f,0x18ac,0x4654,{0xa0,0x4e,0x8b,0x3f,0x81,0x25,0x1c,0x33}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("e6041d7f-18ac-4654-a04e-8b3f81251c33")
    ICoreWebView2ExperimentalCompositionController4 : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_AutomationProvider( 
            /* [retval][out] */ IUnknown **provider) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateCoreWebView2PointerInfoFromPointerId( 
            /* [in] */ UINT pointerId,
            /* [in] */ HWND parentWindow,
            /* [in] */ struct COREWEBVIEW2_MATRIX_4X4 transform,
            /* [retval][out] */ ICoreWebView2PointerInfo **pointerInfo) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalCompositionController4Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalCompositionController4 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalCompositionController4 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalCompositionController4 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCompositionController4, get_AutomationProvider)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_AutomationProvider )( 
            ICoreWebView2ExperimentalCompositionController4 * This,
            /* [retval][out] */ IUnknown **provider);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCompositionController4, CreateCoreWebView2PointerInfoFromPointerId)
        HRESULT ( STDMETHODCALLTYPE *CreateCoreWebView2PointerInfoFromPointerId )( 
            ICoreWebView2ExperimentalCompositionController4 * This,
            /* [in] */ UINT pointerId,
            /* [in] */ HWND parentWindow,
            /* [in] */ struct COREWEBVIEW2_MATRIX_4X4 transform,
            /* [retval][out] */ ICoreWebView2PointerInfo **pointerInfo);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalCompositionController4Vtbl;

    interface ICoreWebView2ExperimentalCompositionController4
    {
        CONST_VTBL struct ICoreWebView2ExperimentalCompositionController4Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalCompositionController4_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalCompositionController4_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalCompositionController4_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalCompositionController4_get_AutomationProvider(This,provider)	\
    ( (This)->lpVtbl -> get_AutomationProvider(This,provider) ) 

#define ICoreWebView2ExperimentalCompositionController4_CreateCoreWebView2PointerInfoFromPointerId(This,pointerId,parentWindow,transform,pointerInfo)	\
    ( (This)->lpVtbl -> CreateCoreWebView2PointerInfoFromPointerId(This,pointerId,parentWindow,transform,pointerInfo) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalCompositionController4_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalControllerOptions_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalControllerOptions_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalControllerOptions */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalControllerOptions = {0x73D95300,0x647F,0x11ED,{0xB7,0xE6,0x0B,0xAD,0xDC,0x91,0xAC,0x6B}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("73D95300-647F-11ED-B7E6-0BADDC91AC6B")
    ICoreWebView2ExperimentalControllerOptions : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_LocaleRegion( 
            /* [retval][out] */ LPWSTR *locale) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_LocaleRegion( 
            /* [in] */ LPCWSTR locale) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalControllerOptionsVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalControllerOptions * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalControllerOptions * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalControllerOptions * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalControllerOptions, get_LocaleRegion)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_LocaleRegion )( 
            ICoreWebView2ExperimentalControllerOptions * This,
            /* [retval][out] */ LPWSTR *locale);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalControllerOptions, put_LocaleRegion)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_LocaleRegion )( 
            ICoreWebView2ExperimentalControllerOptions * This,
            /* [in] */ LPCWSTR locale);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalControllerOptionsVtbl;

    interface ICoreWebView2ExperimentalControllerOptions
    {
        CONST_VTBL struct ICoreWebView2ExperimentalControllerOptionsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalControllerOptions_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalControllerOptions_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalControllerOptions_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalControllerOptions_get_LocaleRegion(This,locale)	\
    ( (This)->lpVtbl -> get_LocaleRegion(This,locale) ) 

#define ICoreWebView2ExperimentalControllerOptions_put_LocaleRegion(This,locale)	\
    ( (This)->lpVtbl -> put_LocaleRegion(This,locale) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalControllerOptions_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalEnvironment3_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalEnvironment3_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalEnvironment3 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalEnvironment3 = {0x9A2BE885,0x7F0B,0x4B26,{0xB6,0xDD,0xC9,0x69,0xBA,0xA0,0x0B,0xF1}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9A2BE885-7F0B-4B26-B6DD-C969BAA00BF1")
    ICoreWebView2ExperimentalEnvironment3 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE UpdateRuntime( 
            /* [in] */ ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler *handler) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalEnvironment3Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalEnvironment3 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalEnvironment3 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalEnvironment3 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalEnvironment3, UpdateRuntime)
        HRESULT ( STDMETHODCALLTYPE *UpdateRuntime )( 
            ICoreWebView2ExperimentalEnvironment3 * This,
            /* [in] */ ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler *handler);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalEnvironment3Vtbl;

    interface ICoreWebView2ExperimentalEnvironment3
    {
        CONST_VTBL struct ICoreWebView2ExperimentalEnvironment3Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalEnvironment3_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalEnvironment3_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalEnvironment3_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalEnvironment3_UpdateRuntime(This,handler)	\
    ( (This)->lpVtbl -> UpdateRuntime(This,handler) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalEnvironment3_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalExecuteScriptResult_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalExecuteScriptResult_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalExecuteScriptResult */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalExecuteScriptResult = {0x0CE15963,0x3698,0x4DF7,{0x93,0x99,0x71,0xED,0x6C,0xDD,0x8C,0x9F}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("0CE15963-3698-4DF7-9399-71ED6CDD8C9F")
    ICoreWebView2ExperimentalExecuteScriptResult : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Succeeded( 
            /* [retval][out] */ BOOL *value) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_ResultAsJson( 
            /* [retval][out] */ LPWSTR *jsonResult) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE TryGetResultAsString( 
            /* [out] */ LPWSTR *stringResult,
            /* [out] */ BOOL *value) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Exception( 
            /* [retval][out] */ ICoreWebView2ExperimentalScriptException **exception) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalExecuteScriptResultVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalExecuteScriptResult * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalExecuteScriptResult * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalExecuteScriptResult * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalExecuteScriptResult, get_Succeeded)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Succeeded )( 
            ICoreWebView2ExperimentalExecuteScriptResult * This,
            /* [retval][out] */ BOOL *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalExecuteScriptResult, get_ResultAsJson)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_ResultAsJson )( 
            ICoreWebView2ExperimentalExecuteScriptResult * This,
            /* [retval][out] */ LPWSTR *jsonResult);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalExecuteScriptResult, TryGetResultAsString)
        HRESULT ( STDMETHODCALLTYPE *TryGetResultAsString )( 
            ICoreWebView2ExperimentalExecuteScriptResult * This,
            /* [out] */ LPWSTR *stringResult,
            /* [out] */ BOOL *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalExecuteScriptResult, get_Exception)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Exception )( 
            ICoreWebView2ExperimentalExecuteScriptResult * This,
            /* [retval][out] */ ICoreWebView2ExperimentalScriptException **exception);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalExecuteScriptResultVtbl;

    interface ICoreWebView2ExperimentalExecuteScriptResult
    {
        CONST_VTBL struct ICoreWebView2ExperimentalExecuteScriptResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalExecuteScriptResult_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalExecuteScriptResult_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalExecuteScriptResult_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalExecuteScriptResult_get_Succeeded(This,value)	\
    ( (This)->lpVtbl -> get_Succeeded(This,value) ) 

#define ICoreWebView2ExperimentalExecuteScriptResult_get_ResultAsJson(This,jsonResult)	\
    ( (This)->lpVtbl -> get_ResultAsJson(This,jsonResult) ) 

#define ICoreWebView2ExperimentalExecuteScriptResult_TryGetResultAsString(This,stringResult,value)	\
    ( (This)->lpVtbl -> TryGetResultAsString(This,stringResult,value) ) 

#define ICoreWebView2ExperimentalExecuteScriptResult_get_Exception(This,exception)	\
    ( (This)->lpVtbl -> get_Exception(This,exception) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalExecuteScriptResult_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler = {0x1BB5317B,0x8238,0x4C67,{0xA7,0xFF,0xBA,0xF6,0x55,0x8F,0x28,0x9D}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("1BB5317B-8238-4C67-A7FF-BAF6558F289D")
    ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Invoke( 
            /* [in] */ HRESULT errorCode,
            /* [in] */ ICoreWebView2ExperimentalExecuteScriptResult *result) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandlerVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler, Invoke)
        HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler * This,
            /* [in] */ HRESULT errorCode,
            /* [in] */ ICoreWebView2ExperimentalExecuteScriptResult *result);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandlerVtbl;

    interface ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler
    {
        CONST_VTBL struct ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandlerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler_Invoke(This,errorCode,result)	\
    ( (This)->lpVtbl -> Invoke(This,errorCode,result) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalExecuteScriptWithResultCompletedHandler_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalScriptException_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalScriptException_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalScriptException */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalScriptException = {0x054DAE00,0x84A3,0x49FF,{0xBC,0x17,0x40,0x12,0xA9,0x0B,0xC9,0xFD}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("054DAE00-84A3-49FF-BC17-4012A90BC9FD")
    ICoreWebView2ExperimentalScriptException : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_LineNumber( 
            /* [retval][out] */ UINT32 *value) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_ColumnNumber( 
            /* [retval][out] */ UINT32 *value) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Name( 
            /* [retval][out] */ LPWSTR *value) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Message( 
            /* [retval][out] */ LPWSTR *value) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_ToJson( 
            /* [retval][out] */ LPWSTR *value) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalScriptExceptionVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalScriptException * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalScriptException * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalScriptException * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalScriptException, get_LineNumber)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_LineNumber )( 
            ICoreWebView2ExperimentalScriptException * This,
            /* [retval][out] */ UINT32 *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalScriptException, get_ColumnNumber)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_ColumnNumber )( 
            ICoreWebView2ExperimentalScriptException * This,
            /* [retval][out] */ UINT32 *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalScriptException, get_Name)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Name )( 
            ICoreWebView2ExperimentalScriptException * This,
            /* [retval][out] */ LPWSTR *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalScriptException, get_Message)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Message )( 
            ICoreWebView2ExperimentalScriptException * This,
            /* [retval][out] */ LPWSTR *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalScriptException, get_ToJson)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_ToJson )( 
            ICoreWebView2ExperimentalScriptException * This,
            /* [retval][out] */ LPWSTR *value);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalScriptExceptionVtbl;

    interface ICoreWebView2ExperimentalScriptException
    {
        CONST_VTBL struct ICoreWebView2ExperimentalScriptExceptionVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalScriptException_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalScriptException_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalScriptException_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalScriptException_get_LineNumber(This,value)	\
    ( (This)->lpVtbl -> get_LineNumber(This,value) ) 

#define ICoreWebView2ExperimentalScriptException_get_ColumnNumber(This,value)	\
    ( (This)->lpVtbl -> get_ColumnNumber(This,value) ) 

#define ICoreWebView2ExperimentalScriptException_get_Name(This,value)	\
    ( (This)->lpVtbl -> get_Name(This,value) ) 

#define ICoreWebView2ExperimentalScriptException_get_Message(This,value)	\
    ( (This)->lpVtbl -> get_Message(This,value) ) 

#define ICoreWebView2ExperimentalScriptException_get_ToJson(This,value)	\
    ( (This)->lpVtbl -> get_ToJson(This,value) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalScriptException_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalEnvironment10_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalEnvironment10_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalEnvironment10 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalEnvironment10 = {0x3C5BACE3,0xFF8E,0x44EA,{0x9C,0x7F,0x05,0xAF,0xA9,0x48,0xA7,0xB1}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("3C5BACE3-FF8E-44EA-9C7F-05AFA948A7B1")
    ICoreWebView2ExperimentalEnvironment10 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE CreateSharedBuffer( 
            /* [in] */ UINT64 size,
            /* [retval][out] */ ICoreWebView2ExperimentalSharedBuffer **shared_buffer) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalEnvironment10Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalEnvironment10 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalEnvironment10 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalEnvironment10 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalEnvironment10, CreateSharedBuffer)
        HRESULT ( STDMETHODCALLTYPE *CreateSharedBuffer )( 
            ICoreWebView2ExperimentalEnvironment10 * This,
            /* [in] */ UINT64 size,
            /* [retval][out] */ ICoreWebView2ExperimentalSharedBuffer **shared_buffer);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalEnvironment10Vtbl;

    interface ICoreWebView2ExperimentalEnvironment10
    {
        CONST_VTBL struct ICoreWebView2ExperimentalEnvironment10Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalEnvironment10_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalEnvironment10_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalEnvironment10_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalEnvironment10_CreateSharedBuffer(This,size,shared_buffer)	\
    ( (This)->lpVtbl -> CreateSharedBuffer(This,size,shared_buffer) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalEnvironment10_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalFrame4_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalFrame4_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalFrame4 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalFrame4 = {0x92CF9F34,0xF403,0x4D46,{0xBF,0xC3,0x0B,0x5E,0xD1,0x7D,0x55,0xCA}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("92CF9F34-F403-4D46-BFC3-0B5ED17D55CA")
    ICoreWebView2ExperimentalFrame4 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE PostSharedBufferToScript( 
            /* [in] */ ICoreWebView2ExperimentalSharedBuffer *sharedBuffer,
            /* [in] */ COREWEBVIEW2_SHARED_BUFFER_ACCESS access,
            /* [in] */ LPCWSTR additionalDataAsJson) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalFrame4Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalFrame4 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalFrame4 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalFrame4 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalFrame4, PostSharedBufferToScript)
        HRESULT ( STDMETHODCALLTYPE *PostSharedBufferToScript )( 
            ICoreWebView2ExperimentalFrame4 * This,
            /* [in] */ ICoreWebView2ExperimentalSharedBuffer *sharedBuffer,
            /* [in] */ COREWEBVIEW2_SHARED_BUFFER_ACCESS access,
            /* [in] */ LPCWSTR additionalDataAsJson);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalFrame4Vtbl;

    interface ICoreWebView2ExperimentalFrame4
    {
        CONST_VTBL struct ICoreWebView2ExperimentalFrame4Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalFrame4_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalFrame4_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalFrame4_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalFrame4_PostSharedBufferToScript(This,sharedBuffer,access,additionalDataAsJson)	\
    ( (This)->lpVtbl -> PostSharedBufferToScript(This,sharedBuffer,access,additionalDataAsJson) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalFrame4_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler = {0x38274481,0xa15c,0x4563,{0x94,0xcf,0x99,0x0e,0xdc,0x9a,0xeb,0x95}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("38274481-a15c-4563-94cf-990edc9aeb95")
    ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Invoke( 
            /* [in] */ HRESULT errorCode,
            /* [in] */ ICoreWebView2ExperimentalPermissionSettingCollectionView *collectionView) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandlerVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler, Invoke)
        HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler * This,
            /* [in] */ HRESULT errorCode,
            /* [in] */ ICoreWebView2ExperimentalPermissionSettingCollectionView *collectionView);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandlerVtbl;

    interface ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler
    {
        CONST_VTBL struct ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandlerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler_Invoke(This,errorCode,collectionView)	\
    ( (This)->lpVtbl -> Invoke(This,errorCode,collectionView) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalPermissionRequestedEventArgs3_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalPermissionRequestedEventArgs3_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalPermissionRequestedEventArgs3 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalPermissionRequestedEventArgs3 = {0xe61670bc,0x3dce,0x4177,{0x86,0xd2,0xc6,0x29,0xae,0x3c,0xb6,0xac}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("e61670bc-3dce-4177-86d2-c629ae3cb6ac")
    ICoreWebView2ExperimentalPermissionRequestedEventArgs3 : public ICoreWebView2PermissionRequestedEventArgs2
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_SavesInProfile( 
            /* [retval][out] */ BOOL *value) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_SavesInProfile( 
            /* [in] */ BOOL value) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalPermissionRequestedEventArgs3Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_Uri)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Uri )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [retval][out] */ LPWSTR *uri);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_PermissionKind)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_PermissionKind )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_KIND *permissionKind);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_IsUserInitiated)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_IsUserInitiated )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [retval][out] */ BOOL *isUserInitiated);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_State)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_State )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_STATE *state);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, put_State)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_State )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [in] */ COREWEBVIEW2_PERMISSION_STATE state);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, GetDeferral)
        HRESULT ( STDMETHODCALLTYPE *GetDeferral )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [retval][out] */ ICoreWebView2Deferral **deferral);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs2, get_Handled)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Handled )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [retval][out] */ BOOL *handled);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs2, put_Handled)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_Handled )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [in] */ BOOL handled);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalPermissionRequestedEventArgs3, get_SavesInProfile)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_SavesInProfile )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [retval][out] */ BOOL *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalPermissionRequestedEventArgs3, put_SavesInProfile)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_SavesInProfile )( 
            ICoreWebView2ExperimentalPermissionRequestedEventArgs3 * This,
            /* [in] */ BOOL value);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalPermissionRequestedEventArgs3Vtbl;

    interface ICoreWebView2ExperimentalPermissionRequestedEventArgs3
    {
        CONST_VTBL struct ICoreWebView2ExperimentalPermissionRequestedEventArgs3Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_get_Uri(This,uri)	\
    ( (This)->lpVtbl -> get_Uri(This,uri) ) 

#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_get_PermissionKind(This,permissionKind)	\
    ( (This)->lpVtbl -> get_PermissionKind(This,permissionKind) ) 

#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_get_IsUserInitiated(This,isUserInitiated)	\
    ( (This)->lpVtbl -> get_IsUserInitiated(This,isUserInitiated) ) 

#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_get_State(This,state)	\
    ( (This)->lpVtbl -> get_State(This,state) ) 

#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_put_State(This,state)	\
    ( (This)->lpVtbl -> put_State(This,state) ) 

#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_GetDeferral(This,deferral)	\
    ( (This)->lpVtbl -> GetDeferral(This,deferral) ) 


#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_get_Handled(This,handled)	\
    ( (This)->lpVtbl -> get_Handled(This,handled) ) 

#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_put_Handled(This,handled)	\
    ( (This)->lpVtbl -> put_Handled(This,handled) ) 


#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_get_SavesInProfile(This,value)	\
    ( (This)->lpVtbl -> get_SavesInProfile(This,value) ) 

#define ICoreWebView2ExperimentalPermissionRequestedEventArgs3_put_SavesInProfile(This,value)	\
    ( (This)->lpVtbl -> put_SavesInProfile(This,value) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalPermissionRequestedEventArgs3_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2PermissionRequestedEventArgs_INTERFACE_DEFINED__
#define __ICoreWebView2PermissionRequestedEventArgs_INTERFACE_DEFINED__

/* interface ICoreWebView2PermissionRequestedEventArgs */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2PermissionRequestedEventArgs = {0x973ae2ef,0xff18,0x4894,{0x8f,0xb2,0x3c,0x75,0x8f,0x04,0x68,0x10}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("973ae2ef-ff18-4894-8fb2-3c758f046810")
    ICoreWebView2PermissionRequestedEventArgs : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Uri( 
            /* [retval][out] */ LPWSTR *uri) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_PermissionKind( 
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_KIND *permissionKind) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_IsUserInitiated( 
            /* [retval][out] */ BOOL *isUserInitiated) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_State( 
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_STATE *state) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_State( 
            /* [in] */ COREWEBVIEW2_PERMISSION_STATE state) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDeferral( 
            /* [retval][out] */ ICoreWebView2Deferral **deferral) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2PermissionRequestedEventArgsVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2PermissionRequestedEventArgs * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2PermissionRequestedEventArgs * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2PermissionRequestedEventArgs * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_Uri)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Uri )( 
            ICoreWebView2PermissionRequestedEventArgs * This,
            /* [retval][out] */ LPWSTR *uri);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_PermissionKind)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_PermissionKind )( 
            ICoreWebView2PermissionRequestedEventArgs * This,
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_KIND *permissionKind);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_IsUserInitiated)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_IsUserInitiated )( 
            ICoreWebView2PermissionRequestedEventArgs * This,
            /* [retval][out] */ BOOL *isUserInitiated);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_State)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_State )( 
            ICoreWebView2PermissionRequestedEventArgs * This,
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_STATE *state);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, put_State)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_State )( 
            ICoreWebView2PermissionRequestedEventArgs * This,
            /* [in] */ COREWEBVIEW2_PERMISSION_STATE state);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, GetDeferral)
        HRESULT ( STDMETHODCALLTYPE *GetDeferral )( 
            ICoreWebView2PermissionRequestedEventArgs * This,
            /* [retval][out] */ ICoreWebView2Deferral **deferral);
        
        END_INTERFACE
    } ICoreWebView2PermissionRequestedEventArgsVtbl;

    interface ICoreWebView2PermissionRequestedEventArgs
    {
        CONST_VTBL struct ICoreWebView2PermissionRequestedEventArgsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2PermissionRequestedEventArgs_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2PermissionRequestedEventArgs_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2PermissionRequestedEventArgs_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2PermissionRequestedEventArgs_get_Uri(This,uri)	\
    ( (This)->lpVtbl -> get_Uri(This,uri) ) 

#define ICoreWebView2PermissionRequestedEventArgs_get_PermissionKind(This,permissionKind)	\
    ( (This)->lpVtbl -> get_PermissionKind(This,permissionKind) ) 

#define ICoreWebView2PermissionRequestedEventArgs_get_IsUserInitiated(This,isUserInitiated)	\
    ( (This)->lpVtbl -> get_IsUserInitiated(This,isUserInitiated) ) 

#define ICoreWebView2PermissionRequestedEventArgs_get_State(This,state)	\
    ( (This)->lpVtbl -> get_State(This,state) ) 

#define ICoreWebView2PermissionRequestedEventArgs_put_State(This,state)	\
    ( (This)->lpVtbl -> put_State(This,state) ) 

#define ICoreWebView2PermissionRequestedEventArgs_GetDeferral(This,deferral)	\
    ( (This)->lpVtbl -> GetDeferral(This,deferral) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2PermissionRequestedEventArgs_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2PermissionRequestedEventArgs2_INTERFACE_DEFINED__
#define __ICoreWebView2PermissionRequestedEventArgs2_INTERFACE_DEFINED__

/* interface ICoreWebView2PermissionRequestedEventArgs2 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2PermissionRequestedEventArgs2 = {0x74d7127f,0x9de6,0x4200,{0x87,0x34,0x42,0xd6,0xfb,0x4f,0xf7,0x41}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("74d7127f-9de6-4200-8734-42d6fb4ff741")
    ICoreWebView2PermissionRequestedEventArgs2 : public ICoreWebView2PermissionRequestedEventArgs
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Handled( 
            /* [retval][out] */ BOOL *handled) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_Handled( 
            /* [in] */ BOOL handled) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2PermissionRequestedEventArgs2Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_Uri)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Uri )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This,
            /* [retval][out] */ LPWSTR *uri);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_PermissionKind)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_PermissionKind )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This,
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_KIND *permissionKind);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_IsUserInitiated)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_IsUserInitiated )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This,
            /* [retval][out] */ BOOL *isUserInitiated);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, get_State)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_State )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This,
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_STATE *state);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, put_State)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_State )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This,
            /* [in] */ COREWEBVIEW2_PERMISSION_STATE state);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs, GetDeferral)
        HRESULT ( STDMETHODCALLTYPE *GetDeferral )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This,
            /* [retval][out] */ ICoreWebView2Deferral **deferral);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs2, get_Handled)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Handled )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This,
            /* [retval][out] */ BOOL *handled);
        
        DECLSPEC_XFGVIRT(ICoreWebView2PermissionRequestedEventArgs2, put_Handled)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_Handled )( 
            ICoreWebView2PermissionRequestedEventArgs2 * This,
            /* [in] */ BOOL handled);
        
        END_INTERFACE
    } ICoreWebView2PermissionRequestedEventArgs2Vtbl;

    interface ICoreWebView2PermissionRequestedEventArgs2
    {
        CONST_VTBL struct ICoreWebView2PermissionRequestedEventArgs2Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2PermissionRequestedEventArgs2_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2PermissionRequestedEventArgs2_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2PermissionRequestedEventArgs2_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2PermissionRequestedEventArgs2_get_Uri(This,uri)	\
    ( (This)->lpVtbl -> get_Uri(This,uri) ) 

#define ICoreWebView2PermissionRequestedEventArgs2_get_PermissionKind(This,permissionKind)	\
    ( (This)->lpVtbl -> get_PermissionKind(This,permissionKind) ) 

#define ICoreWebView2PermissionRequestedEventArgs2_get_IsUserInitiated(This,isUserInitiated)	\
    ( (This)->lpVtbl -> get_IsUserInitiated(This,isUserInitiated) ) 

#define ICoreWebView2PermissionRequestedEventArgs2_get_State(This,state)	\
    ( (This)->lpVtbl -> get_State(This,state) ) 

#define ICoreWebView2PermissionRequestedEventArgs2_put_State(This,state)	\
    ( (This)->lpVtbl -> put_State(This,state) ) 

#define ICoreWebView2PermissionRequestedEventArgs2_GetDeferral(This,deferral)	\
    ( (This)->lpVtbl -> GetDeferral(This,deferral) ) 


#define ICoreWebView2PermissionRequestedEventArgs2_get_Handled(This,handled)	\
    ( (This)->lpVtbl -> get_Handled(This,handled) ) 

#define ICoreWebView2PermissionRequestedEventArgs2_put_Handled(This,handled)	\
    ( (This)->lpVtbl -> put_Handled(This,handled) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2PermissionRequestedEventArgs2_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalPermissionSetting_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalPermissionSetting_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalPermissionSetting */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalPermissionSetting = {0x792b6eca,0x5576,0x421c,{0x91,0x19,0x74,0xeb,0xb3,0xa4,0xff,0xb3}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("792b6eca-5576-421c-9119-74ebb3a4ffb3")
    ICoreWebView2ExperimentalPermissionSetting : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_PermissionKind( 
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_KIND *value) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_PermissionOrigin( 
            /* [retval][out] */ LPWSTR *value) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_PermissionState( 
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_STATE *value) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalPermissionSettingVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalPermissionSetting * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalPermissionSetting * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalPermissionSetting * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalPermissionSetting, get_PermissionKind)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_PermissionKind )( 
            ICoreWebView2ExperimentalPermissionSetting * This,
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_KIND *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalPermissionSetting, get_PermissionOrigin)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_PermissionOrigin )( 
            ICoreWebView2ExperimentalPermissionSetting * This,
            /* [retval][out] */ LPWSTR *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalPermissionSetting, get_PermissionState)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_PermissionState )( 
            ICoreWebView2ExperimentalPermissionSetting * This,
            /* [retval][out] */ COREWEBVIEW2_PERMISSION_STATE *value);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalPermissionSettingVtbl;

    interface ICoreWebView2ExperimentalPermissionSetting
    {
        CONST_VTBL struct ICoreWebView2ExperimentalPermissionSettingVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalPermissionSetting_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalPermissionSetting_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalPermissionSetting_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalPermissionSetting_get_PermissionKind(This,value)	\
    ( (This)->lpVtbl -> get_PermissionKind(This,value) ) 

#define ICoreWebView2ExperimentalPermissionSetting_get_PermissionOrigin(This,value)	\
    ( (This)->lpVtbl -> get_PermissionOrigin(This,value) ) 

#define ICoreWebView2ExperimentalPermissionSetting_get_PermissionState(This,value)	\
    ( (This)->lpVtbl -> get_PermissionState(This,value) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalPermissionSetting_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalPermissionSettingCollectionView_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalPermissionSettingCollectionView_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalPermissionSettingCollectionView */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalPermissionSettingCollectionView = {0xf5596f62,0x3de5,0x47b1,{0x91,0xe8,0xa4,0x10,0x4b,0x59,0x6b,0x96}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("f5596f62-3de5-47b1-91e8-a4104b596b96")
    ICoreWebView2ExperimentalPermissionSettingCollectionView : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE GetValueAtIndex( 
            /* [in] */ UINT32 index,
            /* [retval][out] */ ICoreWebView2ExperimentalPermissionSetting **permissionSetting) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ UINT32 *value) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalPermissionSettingCollectionViewVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalPermissionSettingCollectionView * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalPermissionSettingCollectionView * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalPermissionSettingCollectionView * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalPermissionSettingCollectionView, GetValueAtIndex)
        HRESULT ( STDMETHODCALLTYPE *GetValueAtIndex )( 
            ICoreWebView2ExperimentalPermissionSettingCollectionView * This,
            /* [in] */ UINT32 index,
            /* [retval][out] */ ICoreWebView2ExperimentalPermissionSetting **permissionSetting);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalPermissionSettingCollectionView, get_Count)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            ICoreWebView2ExperimentalPermissionSettingCollectionView * This,
            /* [retval][out] */ UINT32 *value);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalPermissionSettingCollectionViewVtbl;

    interface ICoreWebView2ExperimentalPermissionSettingCollectionView
    {
        CONST_VTBL struct ICoreWebView2ExperimentalPermissionSettingCollectionViewVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalPermissionSettingCollectionView_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalPermissionSettingCollectionView_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalPermissionSettingCollectionView_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalPermissionSettingCollectionView_GetValueAtIndex(This,index,permissionSetting)	\
    ( (This)->lpVtbl -> GetValueAtIndex(This,index,permissionSetting) ) 

#define ICoreWebView2ExperimentalPermissionSettingCollectionView_get_Count(This,value)	\
    ( (This)->lpVtbl -> get_Count(This,value) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalPermissionSettingCollectionView_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalProfile6_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalProfile6_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalProfile6 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalProfile6 = {0xcf9a4b21,0x5022,0x4e67,{0x98,0x3d,0x92,0x2d,0xdd,0x53,0xd4,0xb6}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("cf9a4b21-5022-4e67-983d-922ddd53d4b6")
    ICoreWebView2ExperimentalProfile6 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE SetPermissionState( 
            /* [in] */ COREWEBVIEW2_PERMISSION_KIND permissionKind,
            /* [in] */ LPCWSTR origin,
            /* [in] */ COREWEBVIEW2_PERMISSION_STATE state,
            /* [in] */ ICoreWebView2ExperimentalSetPermissionStateCompletedHandler *completedHandler) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetNonDefaultPermissionSettings( 
            /* [in] */ ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler *completedHandler) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalProfile6Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalProfile6 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalProfile6 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalProfile6 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalProfile6, SetPermissionState)
        HRESULT ( STDMETHODCALLTYPE *SetPermissionState )( 
            ICoreWebView2ExperimentalProfile6 * This,
            /* [in] */ COREWEBVIEW2_PERMISSION_KIND permissionKind,
            /* [in] */ LPCWSTR origin,
            /* [in] */ COREWEBVIEW2_PERMISSION_STATE state,
            /* [in] */ ICoreWebView2ExperimentalSetPermissionStateCompletedHandler *completedHandler);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalProfile6, GetNonDefaultPermissionSettings)
        HRESULT ( STDMETHODCALLTYPE *GetNonDefaultPermissionSettings )( 
            ICoreWebView2ExperimentalProfile6 * This,
            /* [in] */ ICoreWebView2ExperimentalGetNonDefaultPermissionSettingsCompletedHandler *completedHandler);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalProfile6Vtbl;

    interface ICoreWebView2ExperimentalProfile6
    {
        CONST_VTBL struct ICoreWebView2ExperimentalProfile6Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalProfile6_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalProfile6_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalProfile6_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalProfile6_SetPermissionState(This,permissionKind,origin,state,completedHandler)	\
    ( (This)->lpVtbl -> SetPermissionState(This,permissionKind,origin,state,completedHandler) ) 

#define ICoreWebView2ExperimentalProfile6_GetNonDefaultPermissionSettings(This,completedHandler)	\
    ( (This)->lpVtbl -> GetNonDefaultPermissionSettings(This,completedHandler) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalProfile6_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalSetPermissionStateCompletedHandler_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalSetPermissionStateCompletedHandler_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalSetPermissionStateCompletedHandler */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalSetPermissionStateCompletedHandler = {0xfc77fb30,0x9c9e,0x4076,{0xb8,0xc7,0x76,0x44,0xa7,0x03,0xca,0x1b}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("fc77fb30-9c9e-4076-b8c7-7644a703ca1b")
    ICoreWebView2ExperimentalSetPermissionStateCompletedHandler : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Invoke( 
            /* [in] */ HRESULT errorCode) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalSetPermissionStateCompletedHandlerVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalSetPermissionStateCompletedHandler * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalSetPermissionStateCompletedHandler * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalSetPermissionStateCompletedHandler * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalSetPermissionStateCompletedHandler, Invoke)
        HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ICoreWebView2ExperimentalSetPermissionStateCompletedHandler * This,
            /* [in] */ HRESULT errorCode);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalSetPermissionStateCompletedHandlerVtbl;

    interface ICoreWebView2ExperimentalSetPermissionStateCompletedHandler
    {
        CONST_VTBL struct ICoreWebView2ExperimentalSetPermissionStateCompletedHandlerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalSetPermissionStateCompletedHandler_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalSetPermissionStateCompletedHandler_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalSetPermissionStateCompletedHandler_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalSetPermissionStateCompletedHandler_Invoke(This,errorCode)	\
    ( (This)->lpVtbl -> Invoke(This,errorCode) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalSetPermissionStateCompletedHandler_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalSharedBuffer_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalSharedBuffer_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalSharedBuffer */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalSharedBuffer = {0xB747A495,0x0C6F,0x449E,{0x97,0xB8,0x2F,0x81,0xE9,0xD6,0xAB,0x43}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("B747A495-0C6F-449E-97B8-2F81E9D6AB43")
    ICoreWebView2ExperimentalSharedBuffer : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Size( 
            /* [retval][out] */ UINT64 *value) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Buffer( 
            /* [retval][out] */ BYTE **value) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE OpenStream( 
            /* [retval][out] */ IStream **value) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_FileMappingHandle( 
            /* [retval][out] */ HANDLE *value) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Close( void) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalSharedBufferVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalSharedBuffer * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalSharedBuffer * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalSharedBuffer * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalSharedBuffer, get_Size)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Size )( 
            ICoreWebView2ExperimentalSharedBuffer * This,
            /* [retval][out] */ UINT64 *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalSharedBuffer, get_Buffer)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Buffer )( 
            ICoreWebView2ExperimentalSharedBuffer * This,
            /* [retval][out] */ BYTE **value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalSharedBuffer, OpenStream)
        HRESULT ( STDMETHODCALLTYPE *OpenStream )( 
            ICoreWebView2ExperimentalSharedBuffer * This,
            /* [retval][out] */ IStream **value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalSharedBuffer, get_FileMappingHandle)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_FileMappingHandle )( 
            ICoreWebView2ExperimentalSharedBuffer * This,
            /* [retval][out] */ HANDLE *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalSharedBuffer, Close)
        HRESULT ( STDMETHODCALLTYPE *Close )( 
            ICoreWebView2ExperimentalSharedBuffer * This);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalSharedBufferVtbl;

    interface ICoreWebView2ExperimentalSharedBuffer
    {
        CONST_VTBL struct ICoreWebView2ExperimentalSharedBufferVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalSharedBuffer_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalSharedBuffer_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalSharedBuffer_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalSharedBuffer_get_Size(This,value)	\
    ( (This)->lpVtbl -> get_Size(This,value) ) 

#define ICoreWebView2ExperimentalSharedBuffer_get_Buffer(This,value)	\
    ( (This)->lpVtbl -> get_Buffer(This,value) ) 

#define ICoreWebView2ExperimentalSharedBuffer_OpenStream(This,value)	\
    ( (This)->lpVtbl -> OpenStream(This,value) ) 

#define ICoreWebView2ExperimentalSharedBuffer_get_FileMappingHandle(This,value)	\
    ( (This)->lpVtbl -> get_FileMappingHandle(This,value) ) 

#define ICoreWebView2ExperimentalSharedBuffer_Close(This)	\
    ( (This)->lpVtbl -> Close(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalSharedBuffer_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler = {0xF1D2D722,0x3721,0x499C,{0x87,0xF5,0x4C,0x40,0x52,0x60,0x69,0x7A}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F1D2D722-3721-499C-87F5-4C405260697A")
    ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Invoke( 
            /* [in] */ HRESULT errorCode,
            /* [in] */ ICoreWebView2ExperimentalUpdateRuntimeResult *result) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalUpdateRuntimeCompletedHandlerVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler, Invoke)
        HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler * This,
            /* [in] */ HRESULT errorCode,
            /* [in] */ ICoreWebView2ExperimentalUpdateRuntimeResult *result);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalUpdateRuntimeCompletedHandlerVtbl;

    interface ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler
    {
        CONST_VTBL struct ICoreWebView2ExperimentalUpdateRuntimeCompletedHandlerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_Invoke(This,errorCode,result)	\
    ( (This)->lpVtbl -> Invoke(This,errorCode,result) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalUpdateRuntimeResult_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalUpdateRuntimeResult_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalUpdateRuntimeResult */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalUpdateRuntimeResult = {0xDD503E49,0xAB19,0x47C0,{0xB2,0xAD,0x6D,0xDD,0x09,0xCC,0x3E,0x3A}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("DD503E49-AB19-47C0-B2AD-6DDD09CC3E3A")
    ICoreWebView2ExperimentalUpdateRuntimeResult : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Status( 
            /* [retval][out] */ COREWEBVIEW2_UPDATE_RUNTIME_STATUS *status) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_ExtendedError( 
            /* [retval][out] */ HRESULT *error) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalUpdateRuntimeResultVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalUpdateRuntimeResult * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalUpdateRuntimeResult * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalUpdateRuntimeResult * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalUpdateRuntimeResult, get_Status)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Status )( 
            ICoreWebView2ExperimentalUpdateRuntimeResult * This,
            /* [retval][out] */ COREWEBVIEW2_UPDATE_RUNTIME_STATUS *status);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalUpdateRuntimeResult, get_ExtendedError)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_ExtendedError )( 
            ICoreWebView2ExperimentalUpdateRuntimeResult * This,
            /* [retval][out] */ HRESULT *error);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalUpdateRuntimeResultVtbl;

    interface ICoreWebView2ExperimentalUpdateRuntimeResult
    {
        CONST_VTBL struct ICoreWebView2ExperimentalUpdateRuntimeResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalUpdateRuntimeResult_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalUpdateRuntimeResult_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalUpdateRuntimeResult_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalUpdateRuntimeResult_get_Status(This,status)	\
    ( (This)->lpVtbl -> get_Status(This,status) ) 

#define ICoreWebView2ExperimentalUpdateRuntimeResult_get_ExtendedError(This,error)	\
    ( (This)->lpVtbl -> get_ExtendedError(This,error) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalUpdateRuntimeResult_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalWebResourceRequestedEventArgs */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalWebResourceRequestedEventArgs = {0x8f3ec528,0x0596,0x4d51,{0x9f,0x9e,0x2d,0xa5,0x80,0xac,0x97,0x87}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("8f3ec528-0596-4d51-9f9e-2da580ac9787")
    ICoreWebView2ExperimentalWebResourceRequestedEventArgs : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_RequestedSourceKind( 
            /* [retval][out] */ COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS *requestedSourceKind) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalWebResourceRequestedEventArgsVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalWebResourceRequestedEventArgs * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalWebResourceRequestedEventArgs * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalWebResourceRequestedEventArgs * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalWebResourceRequestedEventArgs, get_RequestedSourceKind)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_RequestedSourceKind )( 
            ICoreWebView2ExperimentalWebResourceRequestedEventArgs * This,
            /* [retval][out] */ COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS *requestedSourceKind);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalWebResourceRequestedEventArgsVtbl;

    interface ICoreWebView2ExperimentalWebResourceRequestedEventArgs
    {
        CONST_VTBL struct ICoreWebView2ExperimentalWebResourceRequestedEventArgsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalWebResourceRequestedEventArgs_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalWebResourceRequestedEventArgs_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalWebResourceRequestedEventArgs_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalWebResourceRequestedEventArgs_get_RequestedSourceKind(This,requestedSourceKind)	\
    ( (This)->lpVtbl -> get_RequestedSourceKind(This,requestedSourceKind) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalNavigationStartingEventArgs2_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalNavigationStartingEventArgs2_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalNavigationStartingEventArgs2 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalNavigationStartingEventArgs2 = {0x924C5E75,0x3D03,0x44DE,{0xA4,0x4F,0xF5,0x8C,0x98,0x93,0x6E,0xD0}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("924C5E75-3D03-44DE-A44F-F58C98936ED0")
    ICoreWebView2ExperimentalNavigationStartingEventArgs2 : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_NavigationKind( 
            /* [retval][out] */ COREWEBVIEW2_NAVIGATION_KIND *navigation_kind) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalNavigationStartingEventArgs2Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalNavigationStartingEventArgs2 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalNavigationStartingEventArgs2 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalNavigationStartingEventArgs2 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalNavigationStartingEventArgs2, get_NavigationKind)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_NavigationKind )( 
            ICoreWebView2ExperimentalNavigationStartingEventArgs2 * This,
            /* [retval][out] */ COREWEBVIEW2_NAVIGATION_KIND *navigation_kind);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalNavigationStartingEventArgs2Vtbl;

    interface ICoreWebView2ExperimentalNavigationStartingEventArgs2
    {
        CONST_VTBL struct ICoreWebView2ExperimentalNavigationStartingEventArgs2Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalNavigationStartingEventArgs2_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalNavigationStartingEventArgs2_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalNavigationStartingEventArgs2_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalNavigationStartingEventArgs2_get_NavigationKind(This,navigation_kind)	\
    ( (This)->lpVtbl -> get_NavigationKind(This,navigation_kind) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalNavigationStartingEventArgs2_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalSettings7_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalSettings7_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalSettings7 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalSettings7 = {0xd667d3a7,0xc1b7,0x479f,{0x88,0x33,0xdb,0x75,0x47,0xdf,0x66,0x87}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("d667d3a7-c1b7-479f-8833-db7547df6687")
    ICoreWebView2ExperimentalSettings7 : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_IsReputationCheckingRequired( 
            /* [retval][out] */ BOOL *value) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_IsReputationCheckingRequired( 
            /* [in] */ BOOL value) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalSettings7Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalSettings7 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalSettings7 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalSettings7 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalSettings7, get_IsReputationCheckingRequired)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_IsReputationCheckingRequired )( 
            ICoreWebView2ExperimentalSettings7 * This,
            /* [retval][out] */ BOOL *value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalSettings7, put_IsReputationCheckingRequired)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_IsReputationCheckingRequired )( 
            ICoreWebView2ExperimentalSettings7 * This,
            /* [in] */ BOOL value);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalSettings7Vtbl;

    interface ICoreWebView2ExperimentalSettings7
    {
        CONST_VTBL struct ICoreWebView2ExperimentalSettings7Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalSettings7_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalSettings7_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalSettings7_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalSettings7_get_IsReputationCheckingRequired(This,value)	\
    ( (This)->lpVtbl -> get_IsReputationCheckingRequired(This,value) ) 

#define ICoreWebView2ExperimentalSettings7_put_IsReputationCheckingRequired(This,value)	\
    ( (This)->lpVtbl -> put_IsReputationCheckingRequired(This,value) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalSettings7_INTERFACE_DEFINED__ */

#endif /* __WebView2Experimental_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


