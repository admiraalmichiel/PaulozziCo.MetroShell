﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LightSwitchApplication
{
    #region Entities
    
    /// <summary>
    /// No Modeled Description Available
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    public sealed partial class Clientes : global::Microsoft.LightSwitch.Framework.Base.EntityObject<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the Clientes entity.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public Clientes()
            : this(null)
        {
        }
    
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public Clientes(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.Clientes> entitySet)
            : base(entitySet)
        {
            global::LightSwitchApplication.Clientes.DetailsClass.Initialize(this);
        }
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Clientes_Created();
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Clientes_AllowSaveWithErrors(ref bool result);
    
        #endregion
    
        #region Private Properties
        
        /// <summary>
        /// Gets the Application object for this application.  The Application object provides access to active screens, methods to open screens and access to the current user.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::Microsoft.LightSwitch.IApplication<global::LightSwitchApplication.DataWorkspace> Application
        {
            get
            {
                return global::LightSwitchApplication.Application.Current;
            }
        }
        
        /// <summary>
        /// Gets the containing data workspace.  The data workspace provides access to all data sources in the application.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::LightSwitchApplication.DataWorkspace DataWorkspace
        {
            get
            {
                return (global::LightSwitchApplication.DataWorkspace)this.Details.EntitySet.Details.DataService.Details.DataWorkspace;
            }
        }
        
        #endregion
    
        #region Public Properties
    
        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public int Id
        {
            get
            {
                return global::LightSwitchApplication.Clientes.DetailsClass.GetValue(this, global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.Id);
            }
            set
            {
                global::LightSwitchApplication.Clientes.DetailsClass.SetValue(this, global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.Id, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Id_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Id_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Id_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public byte[] RowVersion
        {
            get
            {
                return global::LightSwitchApplication.Clientes.DetailsClass.GetValue(this, global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.RowVersion);
            }
            set
            {
                global::LightSwitchApplication.Clientes.DetailsClass.SetValue(this, global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.RowVersion, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void RowVersion_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void RowVersion_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void RowVersion_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string Nome
        {
            get
            {
                return global::LightSwitchApplication.Clientes.DetailsClass.GetValue(this, global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.Nome);
            }
            set
            {
                global::LightSwitchApplication.Clientes.DetailsClass.SetValue(this, global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.Nome, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Nome_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Nome_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Nome_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string Sobrenome
        {
            get
            {
                return global::LightSwitchApplication.Clientes.DetailsClass.GetValue(this, global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.Sobrenome);
            }
            set
            {
                global::LightSwitchApplication.Clientes.DetailsClass.SetValue(this, global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.Sobrenome, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Sobrenome_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Sobrenome_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Sobrenome_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string RG
        {
            get
            {
                return global::LightSwitchApplication.Clientes.DetailsClass.GetValue(this, global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.RG);
            }
            set
            {
                global::LightSwitchApplication.Clientes.DetailsClass.SetValue(this, global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.RG, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void RG_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void RG_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void RG_Changed();

        #endregion
    
        #region Details Class
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public sealed class DetailsClass : global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<
                global::LightSwitchApplication.Clientes,
                global::LightSwitchApplication.Clientes.DetailsClass,
                global::LightSwitchApplication.Clientes.DetailsClass.IImplementation,
                global::LightSwitchApplication.Clientes.DetailsClass.PropertySet,
                global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass>,
                global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass>>
        {
    
            static DetailsClass()
            {
                var initializeEntry = global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.Id;
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass>.Entry
                __ClientesEntry = new global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass>.Entry(
                    global::LightSwitchApplication.Clientes.DetailsClass.__Clientes_CreateNew,
                    global::LightSwitchApplication.Clientes.DetailsClass.__Clientes_Created,
                    global::LightSwitchApplication.Clientes.DetailsClass.__Clientes_AllowSaveWithErrors);
            private static global::LightSwitchApplication.Clientes __Clientes_CreateNew(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.Clientes> es)
            {
                return new global::LightSwitchApplication.Clientes(es);
            }
            private static void __Clientes_Created(global::LightSwitchApplication.Clientes e)
            {
                e.Clientes_Created();
            }
            private static bool __Clientes_AllowSaveWithErrors(global::LightSwitchApplication.Clientes e)
            {
                bool result = false;
                e.Clientes_AllowSaveWithErrors(ref result);
                return result;
            }
    
            public DetailsClass() : base()
            {
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass> Commands
            {
                get
                {
                    return base.Commands;
                }
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass> Methods
            {
                get
                {
                    return base.Methods;
                }
            }
    
            public new global::LightSwitchApplication.Clientes.DetailsClass.PropertySet Properties
            {
                get
                {
                    return base.Properties;
                }
            }
    
            [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public sealed class PropertySet : global::Microsoft.LightSwitch.Details.Framework.Base.EntityPropertySet<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass>
            {
    
                public PropertySet() : base()
                {
                }
    
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, int> Id
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.Id) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, int>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, byte[]> RowVersion
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.RowVersion) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, byte[]>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string> Nome
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.Nome) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string> Sobrenome
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.Sobrenome) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string> RG
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties.RG) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>;
                    }
                }
                
            }
    
            #pragma warning disable 109
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
            public interface IImplementation : global::Microsoft.LightSwitch.Internal.IEntityImplementation
            {
                new int Id { get; set; }
                new byte[] RowVersion { get; set; }
                new string Nome { get; set; }
                new string Sobrenome { get; set; }
                new string RG { get; set; }
            }
            #pragma warning restore 109
    
            [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal class PropertySetProperties
            {
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, int>.Entry
                    Id = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, int>.Entry(
                        "Id",
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Id_Stub,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Id_ComputeIsReadOnly,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Id_Validate,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Id_GetImplementationValue,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Id_SetImplementationValue,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Id_OnValueChanged);
                private static void _Id_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.Clientes.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, int>.Data> c, global::LightSwitchApplication.Clientes.DetailsClass d, object sf)
                {
                    c(d, ref d._Id, sf);
                }
                private static bool _Id_ComputeIsReadOnly(global::LightSwitchApplication.Clientes e)
                {
                    bool result = false;
                    e.Id_IsReadOnly(ref result);
                    return result;
                }
                private static void _Id_Validate(global::LightSwitchApplication.Clientes e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.Id_Validate(r);
                }
                private static int _Id_GetImplementationValue(global::LightSwitchApplication.Clientes.DetailsClass d)
                {
                    return d.ImplementationEntity.Id;
                }
                private static void _Id_SetImplementationValue(global::LightSwitchApplication.Clientes.DetailsClass d, int v)
                {
                    d.ImplementationEntity.Id = v;
                }
                private static void _Id_OnValueChanged(global::LightSwitchApplication.Clientes e)
                {
                    e.Id_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, byte[]>.Entry
                    RowVersion = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, byte[]>.Entry(
                        "RowVersion",
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RowVersion_Stub,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RowVersion_ComputeIsReadOnly,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RowVersion_Validate,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RowVersion_GetImplementationValue,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RowVersion_SetImplementationValue,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RowVersion_OnValueChanged);
                private static void _RowVersion_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.Clientes.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, byte[]>.Data> c, global::LightSwitchApplication.Clientes.DetailsClass d, object sf)
                {
                    c(d, ref d._RowVersion, sf);
                }
                private static bool _RowVersion_ComputeIsReadOnly(global::LightSwitchApplication.Clientes e)
                {
                    bool result = false;
                    e.RowVersion_IsReadOnly(ref result);
                    return result;
                }
                private static void _RowVersion_Validate(global::LightSwitchApplication.Clientes e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.RowVersion_Validate(r);
                }
                private static byte[] _RowVersion_GetImplementationValue(global::LightSwitchApplication.Clientes.DetailsClass d)
                {
                    return d.ImplementationEntity.RowVersion;
                }
                private static void _RowVersion_SetImplementationValue(global::LightSwitchApplication.Clientes.DetailsClass d, byte[] v)
                {
                    d.ImplementationEntity.RowVersion = v;
                }
                private static void _RowVersion_OnValueChanged(global::LightSwitchApplication.Clientes e)
                {
                    e.RowVersion_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Entry
                    Nome = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Entry(
                        "Nome",
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Nome_Stub,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Nome_ComputeIsReadOnly,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Nome_Validate,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Nome_GetImplementationValue,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Nome_SetImplementationValue,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Nome_OnValueChanged);
                private static void _Nome_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.Clientes.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Data> c, global::LightSwitchApplication.Clientes.DetailsClass d, object sf)
                {
                    c(d, ref d._Nome, sf);
                }
                private static bool _Nome_ComputeIsReadOnly(global::LightSwitchApplication.Clientes e)
                {
                    bool result = false;
                    e.Nome_IsReadOnly(ref result);
                    return result;
                }
                private static void _Nome_Validate(global::LightSwitchApplication.Clientes e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.Nome_Validate(r);
                }
                private static string _Nome_GetImplementationValue(global::LightSwitchApplication.Clientes.DetailsClass d)
                {
                    return d.ImplementationEntity.Nome;
                }
                private static void _Nome_SetImplementationValue(global::LightSwitchApplication.Clientes.DetailsClass d, string v)
                {
                    d.ImplementationEntity.Nome = v;
                }
                private static void _Nome_OnValueChanged(global::LightSwitchApplication.Clientes e)
                {
                    e.Nome_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Entry
                    Sobrenome = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Entry(
                        "Sobrenome",
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Sobrenome_Stub,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Sobrenome_ComputeIsReadOnly,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Sobrenome_Validate,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Sobrenome_GetImplementationValue,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Sobrenome_SetImplementationValue,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._Sobrenome_OnValueChanged);
                private static void _Sobrenome_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.Clientes.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Data> c, global::LightSwitchApplication.Clientes.DetailsClass d, object sf)
                {
                    c(d, ref d._Sobrenome, sf);
                }
                private static bool _Sobrenome_ComputeIsReadOnly(global::LightSwitchApplication.Clientes e)
                {
                    bool result = false;
                    e.Sobrenome_IsReadOnly(ref result);
                    return result;
                }
                private static void _Sobrenome_Validate(global::LightSwitchApplication.Clientes e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.Sobrenome_Validate(r);
                }
                private static string _Sobrenome_GetImplementationValue(global::LightSwitchApplication.Clientes.DetailsClass d)
                {
                    return d.ImplementationEntity.Sobrenome;
                }
                private static void _Sobrenome_SetImplementationValue(global::LightSwitchApplication.Clientes.DetailsClass d, string v)
                {
                    d.ImplementationEntity.Sobrenome = v;
                }
                private static void _Sobrenome_OnValueChanged(global::LightSwitchApplication.Clientes e)
                {
                    e.Sobrenome_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Entry
                    RG = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Entry(
                        "RG",
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RG_Stub,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RG_ComputeIsReadOnly,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RG_Validate,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RG_GetImplementationValue,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RG_SetImplementationValue,
                        global::LightSwitchApplication.Clientes.DetailsClass.PropertySetProperties._RG_OnValueChanged);
                private static void _RG_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.Clientes.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Data> c, global::LightSwitchApplication.Clientes.DetailsClass d, object sf)
                {
                    c(d, ref d._RG, sf);
                }
                private static bool _RG_ComputeIsReadOnly(global::LightSwitchApplication.Clientes e)
                {
                    bool result = false;
                    e.RG_IsReadOnly(ref result);
                    return result;
                }
                private static void _RG_Validate(global::LightSwitchApplication.Clientes e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.RG_Validate(r);
                }
                private static string _RG_GetImplementationValue(global::LightSwitchApplication.Clientes.DetailsClass d)
                {
                    return d.ImplementationEntity.RG;
                }
                private static void _RG_SetImplementationValue(global::LightSwitchApplication.Clientes.DetailsClass d, string v)
                {
                    d.ImplementationEntity.RG = v;
                }
                private static void _RG_OnValueChanged(global::LightSwitchApplication.Clientes e)
                {
                    e.RG_Changed();
                }
    
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, int>.Data _Id;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, byte[]>.Data _RowVersion;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Data _Nome;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Data _Sobrenome;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Clientes, global::LightSwitchApplication.Clientes.DetailsClass, string>.Data _RG;
            
        }
    
        #endregion
    }
    
    #endregion
}