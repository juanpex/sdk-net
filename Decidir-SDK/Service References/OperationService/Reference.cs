﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Decidir_SDK.OperationService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:Decidir.net", ConfigurationName="OperationService.OperationPortType")]
    public interface OperationPortType {
        
        // CODEGEN: Generating message contract since the wrapper name (Operations) of message GetResponse does not match the default value (Get)
        [System.ServiceModel.OperationContractAttribute(Action="urn:Get", ReplyAction="urn:GetResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(string), Action="urn:GetDataServiceFault", Name="DataServiceFault", Namespace="http://ws.wso2.org/dataservice")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Decidir_SDK.OperationService.GetResponse Get(Decidir_SDK.OperationService.GetRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:Decidir.net")]
    public partial class Error : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string eRRCODEField;
        
        private string eRRDESCField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ERRCODE {
            get {
                return this.eRRCODEField;
            }
            set {
                this.eRRCODEField = value;
                this.RaisePropertyChanged("ERRCODE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ERRDESC {
            get {
                return this.eRRDESCField;
            }
            set {
                this.eRRDESCField = value;
                this.RaisePropertyChanged("ERRDESC");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:Decidir.net")]
    public partial class SUBTRANSACTION : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string iDTRANSACCIONSITEField;
        
        private string mONTOField;
        
        private string cUOTASField;
        
        private string nROTICKETField;
        
        private string eSTADO_DESCRIField;
        
        private string iDMOTIVOField;
        
        private string mOTIVO_ADICIONALField;
        
        private string cODAUTField;
        
        private string mOTIVOField;
        
        private string iDSITEField;
        
        private string iDESTADOField;
        
        private string tERMINALField;
        
        private string lOTEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string IDTRANSACCIONSITE {
            get {
                return this.iDTRANSACCIONSITEField;
            }
            set {
                this.iDTRANSACCIONSITEField = value;
                this.RaisePropertyChanged("IDTRANSACCIONSITE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public string MONTO {
            get {
                return this.mONTOField;
            }
            set {
                this.mONTOField = value;
                this.RaisePropertyChanged("MONTO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        public string CUOTAS {
            get {
                return this.cUOTASField;
            }
            set {
                this.cUOTASField = value;
                this.RaisePropertyChanged("CUOTAS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        public string NROTICKET {
            get {
                return this.nROTICKETField;
            }
            set {
                this.nROTICKETField = value;
                this.RaisePropertyChanged("NROTICKET");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=4)]
        public string ESTADO_DESCRI {
            get {
                return this.eSTADO_DESCRIField;
            }
            set {
                this.eSTADO_DESCRIField = value;
                this.RaisePropertyChanged("ESTADO_DESCRI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=5)]
        public string IDMOTIVO {
            get {
                return this.iDMOTIVOField;
            }
            set {
                this.iDMOTIVOField = value;
                this.RaisePropertyChanged("IDMOTIVO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=6)]
        public string MOTIVO_ADICIONAL {
            get {
                return this.mOTIVO_ADICIONALField;
            }
            set {
                this.mOTIVO_ADICIONALField = value;
                this.RaisePropertyChanged("MOTIVO_ADICIONAL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=7)]
        public string CODAUT {
            get {
                return this.cODAUTField;
            }
            set {
                this.cODAUTField = value;
                this.RaisePropertyChanged("CODAUT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=8)]
        public string MOTIVO {
            get {
                return this.mOTIVOField;
            }
            set {
                this.mOTIVOField = value;
                this.RaisePropertyChanged("MOTIVO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=9)]
        public string IDSITE {
            get {
                return this.iDSITEField;
            }
            set {
                this.iDSITEField = value;
                this.RaisePropertyChanged("IDSITE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=10)]
        public string IDESTADO {
            get {
                return this.iDESTADOField;
            }
            set {
                this.iDESTADOField = value;
                this.RaisePropertyChanged("IDESTADO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=11)]
        public string TERMINAL {
            get {
                return this.tERMINALField;
            }
            set {
                this.tERMINALField = value;
                this.RaisePropertyChanged("TERMINAL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=12)]
        public string LOTE {
            get {
                return this.lOTEField;
            }
            set {
                this.lOTEField = value;
                this.RaisePropertyChanged("LOTE");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:Decidir.net")]
    public partial class Operation : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string iDTRANSACCIONSITEField;
        
        private string fECHA_ORIGINALField;
        
        private string mONTOField;
        
        private string cUOTASField;
        
        private string nROTICKETField;
        
        private string eSTADO_DESCRIField;
        
        private string iDMOTIVOField;
        
        private string mOTIVO_ADICIONALField;
        
        private string tITULARField;
        
        private string iDTIPODOCField;
        
        private string nRODOCField;
        
        private string tIPODOCField;
        
        private string cODAUTField;
        
        private string nROTARJ4Field;
        
        private string mOTIVOField;
        
        private string vALDOMField;
        
        private string mAILField;
        
        private string iDSITEField;
        
        private string iDESTADOField;
        
        private string iDMEDIOPAGOField;
        
        private string mEDIOPAGO_DESCRIField;
        
        private string sEXOTITULARField;
        
        private string cALLEField;
        
        private string nROPUERTAField;
        
        private string pARAMSITIOField;
        
        private string fECHAVTOCUOTA1Field;
        
        private string iDOPERACIONMEDIOPAGOField;
        
        private string tERMINALField;
        
        private string lOTEField;
        
        private string rESULTADOCSField;
        
        private string iDENTIFICADORCSField;
        
        private SUBTRANSACTION[] sUBTRANSACTIONSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string IDTRANSACCIONSITE {
            get {
                return this.iDTRANSACCIONSITEField;
            }
            set {
                this.iDTRANSACCIONSITEField = value;
                this.RaisePropertyChanged("IDTRANSACCIONSITE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public string FECHA_ORIGINAL {
            get {
                return this.fECHA_ORIGINALField;
            }
            set {
                this.fECHA_ORIGINALField = value;
                this.RaisePropertyChanged("FECHA_ORIGINAL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        public string MONTO {
            get {
                return this.mONTOField;
            }
            set {
                this.mONTOField = value;
                this.RaisePropertyChanged("MONTO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        public string CUOTAS {
            get {
                return this.cUOTASField;
            }
            set {
                this.cUOTASField = value;
                this.RaisePropertyChanged("CUOTAS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=4)]
        public string NROTICKET {
            get {
                return this.nROTICKETField;
            }
            set {
                this.nROTICKETField = value;
                this.RaisePropertyChanged("NROTICKET");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=5)]
        public string ESTADO_DESCRI {
            get {
                return this.eSTADO_DESCRIField;
            }
            set {
                this.eSTADO_DESCRIField = value;
                this.RaisePropertyChanged("ESTADO_DESCRI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=6)]
        public string IDMOTIVO {
            get {
                return this.iDMOTIVOField;
            }
            set {
                this.iDMOTIVOField = value;
                this.RaisePropertyChanged("IDMOTIVO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=7)]
        public string MOTIVO_ADICIONAL {
            get {
                return this.mOTIVO_ADICIONALField;
            }
            set {
                this.mOTIVO_ADICIONALField = value;
                this.RaisePropertyChanged("MOTIVO_ADICIONAL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=8)]
        public string TITULAR {
            get {
                return this.tITULARField;
            }
            set {
                this.tITULARField = value;
                this.RaisePropertyChanged("TITULAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=9)]
        public string IDTIPODOC {
            get {
                return this.iDTIPODOCField;
            }
            set {
                this.iDTIPODOCField = value;
                this.RaisePropertyChanged("IDTIPODOC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=10)]
        public string NRODOC {
            get {
                return this.nRODOCField;
            }
            set {
                this.nRODOCField = value;
                this.RaisePropertyChanged("NRODOC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=11)]
        public string TIPODOC {
            get {
                return this.tIPODOCField;
            }
            set {
                this.tIPODOCField = value;
                this.RaisePropertyChanged("TIPODOC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=12)]
        public string CODAUT {
            get {
                return this.cODAUTField;
            }
            set {
                this.cODAUTField = value;
                this.RaisePropertyChanged("CODAUT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=13)]
        public string NROTARJ4 {
            get {
                return this.nROTARJ4Field;
            }
            set {
                this.nROTARJ4Field = value;
                this.RaisePropertyChanged("NROTARJ4");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=14)]
        public string MOTIVO {
            get {
                return this.mOTIVOField;
            }
            set {
                this.mOTIVOField = value;
                this.RaisePropertyChanged("MOTIVO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=15)]
        public string VALDOM {
            get {
                return this.vALDOMField;
            }
            set {
                this.vALDOMField = value;
                this.RaisePropertyChanged("VALDOM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=16)]
        public string MAIL {
            get {
                return this.mAILField;
            }
            set {
                this.mAILField = value;
                this.RaisePropertyChanged("MAIL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=17)]
        public string IDSITE {
            get {
                return this.iDSITEField;
            }
            set {
                this.iDSITEField = value;
                this.RaisePropertyChanged("IDSITE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=18)]
        public string IDESTADO {
            get {
                return this.iDESTADOField;
            }
            set {
                this.iDESTADOField = value;
                this.RaisePropertyChanged("IDESTADO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=19)]
        public string IDMEDIOPAGO {
            get {
                return this.iDMEDIOPAGOField;
            }
            set {
                this.iDMEDIOPAGOField = value;
                this.RaisePropertyChanged("IDMEDIOPAGO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=20)]
        public string MEDIOPAGO_DESCRI {
            get {
                return this.mEDIOPAGO_DESCRIField;
            }
            set {
                this.mEDIOPAGO_DESCRIField = value;
                this.RaisePropertyChanged("MEDIOPAGO_DESCRI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=21)]
        public string SEXOTITULAR {
            get {
                return this.sEXOTITULARField;
            }
            set {
                this.sEXOTITULARField = value;
                this.RaisePropertyChanged("SEXOTITULAR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=22)]
        public string CALLE {
            get {
                return this.cALLEField;
            }
            set {
                this.cALLEField = value;
                this.RaisePropertyChanged("CALLE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=23)]
        public string NROPUERTA {
            get {
                return this.nROPUERTAField;
            }
            set {
                this.nROPUERTAField = value;
                this.RaisePropertyChanged("NROPUERTA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=24)]
        public string PARAMSITIO {
            get {
                return this.pARAMSITIOField;
            }
            set {
                this.pARAMSITIOField = value;
                this.RaisePropertyChanged("PARAMSITIO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=25)]
        public string FECHAVTOCUOTA1 {
            get {
                return this.fECHAVTOCUOTA1Field;
            }
            set {
                this.fECHAVTOCUOTA1Field = value;
                this.RaisePropertyChanged("FECHAVTOCUOTA1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=26)]
        public string IDOPERACIONMEDIOPAGO {
            get {
                return this.iDOPERACIONMEDIOPAGOField;
            }
            set {
                this.iDOPERACIONMEDIOPAGOField = value;
                this.RaisePropertyChanged("IDOPERACIONMEDIOPAGO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=27)]
        public string TERMINAL {
            get {
                return this.tERMINALField;
            }
            set {
                this.tERMINALField = value;
                this.RaisePropertyChanged("TERMINAL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=28)]
        public string LOTE {
            get {
                return this.lOTEField;
            }
            set {
                this.lOTEField = value;
                this.RaisePropertyChanged("LOTE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=29)]
        public string RESULTADOCS {
            get {
                return this.rESULTADOCSField;
            }
            set {
                this.rESULTADOCSField = value;
                this.RaisePropertyChanged("RESULTADOCS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=30)]
        public string IDENTIFICADORCS {
            get {
                return this.iDENTIFICADORCSField;
            }
            set {
                this.iDENTIFICADORCSField = value;
                this.RaisePropertyChanged("IDENTIFICADORCS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=31)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public SUBTRANSACTION[] SUBTRANSACTIONS {
            get {
                return this.sUBTRANSACTIONSField;
            }
            set {
                this.sUBTRANSACTIONSField = value;
                this.RaisePropertyChanged("SUBTRANSACTIONS");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Get", WrapperNamespace="urn:Decidir.net", IsWrapped=true)]
    public partial class GetRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:Decidir.net", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IDSITE;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:Decidir.net", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IDTRANSACTIONSIT;
        
        public GetRequest() {
        }
        
        public GetRequest(string IDSITE, string IDTRANSACTIONSIT) {
            this.IDSITE = IDSITE;
            this.IDTRANSACTIONSIT = IDTRANSACTIONSIT;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Operations", WrapperNamespace="urn:Decidir.net", IsWrapped=true)]
    public partial class GetResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:Decidir.net", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("Error", typeof(Error))]
        [System.Xml.Serialization.XmlElementAttribute("Operation", typeof(Operation))]
        public object[] Items;
        
        public GetResponse() {
        }
        
        public GetResponse(object[] Items) {
            this.Items = Items;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OperationPortTypeChannel : Decidir_SDK.OperationService.OperationPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OperationPortTypeClient : System.ServiceModel.ClientBase<Decidir_SDK.OperationService.OperationPortType>, Decidir_SDK.OperationService.OperationPortType {
        
        public OperationPortTypeClient() {
        }
        
        public OperationPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OperationPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperationPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperationPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Decidir_SDK.OperationService.GetResponse Decidir_SDK.OperationService.OperationPortType.Get(Decidir_SDK.OperationService.GetRequest request) {
            return base.Channel.Get(request);
        }
        
        public object[] Get(string IDSITE, string IDTRANSACTIONSIT) {
            Decidir_SDK.OperationService.GetRequest inValue = new Decidir_SDK.OperationService.GetRequest();
            inValue.IDSITE = IDSITE;
            inValue.IDTRANSACTIONSIT = IDTRANSACTIONSIT;
            Decidir_SDK.OperationService.GetResponse retVal = ((Decidir_SDK.OperationService.OperationPortType)(this)).Get(inValue);
            return retVal.Items;
        }
    }
}
