﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using CommonLibrary.Configuaration;
using EServicesCommon.DI;

namespace ERP_AccountsService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://service.dirac.com/", ConfigurationName="ERP_AccountsService.AccountsService")]
    public interface AccountsService
    {
        
        // CODEGEN: Parameter 'accounts' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'Microsoft.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="accounts")]
        ERP_AccountsService.findAllAccountsResponse findAllAccounts(ERP_AccountsService.findAllAccounts request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<ERP_AccountsService.findAllAccountsResponse> findAllAccountsAsync(ERP_AccountsService.findAllAccounts request);
        
        // CODEGEN: Parameter 'accountsinfo' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'Microsoft.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="accountsinfo")]
        ERP_AccountsService.getAccountBudgetInfoResponse getAccountBudgetInfo(ERP_AccountsService.getAccountBudgetInfo request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<ERP_AccountsService.getAccountBudgetInfoResponse> getAccountBudgetInfoAsync(ERP_AccountsService.getAccountBudgetInfo request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service.dirac.com/")]
    public partial class accounts
    {
        
        private string account_nameField;
        
        private string account_codeField;
        
        private decimal availablebudgetField;
        
        private long idField;
        
        private string subaccounttypeField;
        
        private string subaccounttypetrlField;
        
        private string reportsubtypeField;
        
        private string reportsubtypetrlField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string account_name
        {
            get
            {
                return this.account_nameField;
            }
            set
            {
                this.account_nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string account_code
        {
            get
            {
                return this.account_codeField;
            }
            set
            {
                this.account_codeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public decimal availablebudget
        {
            get
            {
                return this.availablebudgetField;
            }
            set
            {
                this.availablebudgetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public long id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string subaccounttype
        {
            get
            {
                return this.subaccounttypeField;
            }
            set
            {
                this.subaccounttypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string subaccounttypetrl
        {
            get
            {
                return this.subaccounttypetrlField;
            }
            set
            {
                this.subaccounttypetrlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string reportsubtype
        {
            get
            {
                return this.reportsubtypeField;
            }
            set
            {
                this.reportsubtypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public string reportsubtypetrl
        {
            get
            {
                return this.reportsubtypetrlField;
            }
            set
            {
                this.reportsubtypetrlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service.dirac.com/")]
    public partial class accountsInfo
    {
        
        private long idField;
        
        private decimal aLLYEARSBUDGETField;
        
        private decimal oRIGINALBUDGETAMTField;
        
        private decimal totalBudgetField;
        
        private decimal actualAmtField;
        
        private decimal nOTISSUEDAMTField;
        
        private decimal totalCommitmentField;
        
        private decimal oPENCOMMITMENTField;
        
        private decimal remBudgetField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public long id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public decimal ALLYEARSBUDGET
        {
            get
            {
                return this.aLLYEARSBUDGETField;
            }
            set
            {
                this.aLLYEARSBUDGETField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public decimal ORIGINALBUDGETAMT
        {
            get
            {
                return this.oRIGINALBUDGETAMTField;
            }
            set
            {
                this.oRIGINALBUDGETAMTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public decimal TotalBudget
        {
            get
            {
                return this.totalBudgetField;
            }
            set
            {
                this.totalBudgetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public decimal ActualAmt
        {
            get
            {
                return this.actualAmtField;
            }
            set
            {
                this.actualAmtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public decimal NOTISSUEDAMT
        {
            get
            {
                return this.nOTISSUEDAMTField;
            }
            set
            {
                this.nOTISSUEDAMTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public decimal TotalCommitment
        {
            get
            {
                return this.totalCommitmentField;
            }
            set
            {
                this.totalCommitmentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public decimal OPENCOMMITMENT
        {
            get
            {
                return this.oPENCOMMITMENTField;
            }
            set
            {
                this.oPENCOMMITMENTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public decimal RemBudget
        {
            get
            {
                return this.remBudgetField;
            }
            set
            {
                this.remBudgetField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findAllAccounts", WrapperNamespace="http://service.dirac.com/", IsWrapped=true)]
    public partial class findAllAccounts
    {
        
        public findAllAccounts()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findAllAccountsResponse", WrapperNamespace="http://service.dirac.com/", IsWrapped=true)]
    public partial class findAllAccountsResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.dirac.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("accounts", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ERP_AccountsService.accounts[] accounts;
        
        public findAllAccountsResponse()
        {
        }
        
        public findAllAccountsResponse(ERP_AccountsService.accounts[] accounts)
        {
            this.accounts = accounts;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getAccountBudgetInfo", WrapperNamespace="http://service.dirac.com/", IsWrapped=true)]
    public partial class getAccountBudgetInfo
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.dirac.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long accountid;
        
        public getAccountBudgetInfo()
        {
        }
        
        public getAccountBudgetInfo(long accountid)
        {
            this.accountid = accountid;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getAccountBudgetInfoResponse", WrapperNamespace="http://service.dirac.com/", IsWrapped=true)]
    public partial class getAccountBudgetInfoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.dirac.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ERP_AccountsService.accountsInfo accountsinfo;
        
        public getAccountBudgetInfoResponse()
        {
        }
        
        public getAccountBudgetInfoResponse(ERP_AccountsService.accountsInfo accountsinfo)
        {
            this.accountsinfo = accountsinfo;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    public interface AccountsServiceChannel : ERP_AccountsService.AccountsService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30422-0661")]
    public partial class AccountsServiceClient : System.ServiceModel.ClientBase<ERP_AccountsService.AccountsService>, ERP_AccountsService.AccountsService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public AccountsServiceClient() : 
                base(AccountsServiceClient.GetDefaultBinding(), AccountsServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.AccountsServiceImplPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AccountsServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(AccountsServiceClient.GetBindingForEndpoint(endpointConfiguration), AccountsServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AccountsServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(AccountsServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AccountsServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(AccountsServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AccountsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ERP_AccountsService.findAllAccountsResponse ERP_AccountsService.AccountsService.findAllAccounts(ERP_AccountsService.findAllAccounts request)
        {
            return base.Channel.findAllAccounts(request);
        }
        
        public ERP_AccountsService.accounts[] findAllAccounts()
        {
            ERP_AccountsService.findAllAccounts inValue = new ERP_AccountsService.findAllAccounts();
            ERP_AccountsService.findAllAccountsResponse retVal = ((ERP_AccountsService.AccountsService)(this)).findAllAccounts(inValue);
            return retVal.accounts;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ERP_AccountsService.findAllAccountsResponse> ERP_AccountsService.AccountsService.findAllAccountsAsync(ERP_AccountsService.findAllAccounts request)
        {
            return base.Channel.findAllAccountsAsync(request);
        }
        
        public System.Threading.Tasks.Task<ERP_AccountsService.findAllAccountsResponse> findAllAccountsAsync()
        {
            ERP_AccountsService.findAllAccounts inValue = new ERP_AccountsService.findAllAccounts();
            return ((ERP_AccountsService.AccountsService)(this)).findAllAccountsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ERP_AccountsService.getAccountBudgetInfoResponse ERP_AccountsService.AccountsService.getAccountBudgetInfo(ERP_AccountsService.getAccountBudgetInfo request)
        {
            return base.Channel.getAccountBudgetInfo(request);
        }
        
        public ERP_AccountsService.accountsInfo getAccountBudgetInfo(long accountid)
        {
            ERP_AccountsService.getAccountBudgetInfo inValue = new ERP_AccountsService.getAccountBudgetInfo();
            inValue.accountid = accountid;
            ERP_AccountsService.getAccountBudgetInfoResponse retVal = ((ERP_AccountsService.AccountsService)(this)).getAccountBudgetInfo(inValue);
            return retVal.accountsinfo;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ERP_AccountsService.getAccountBudgetInfoResponse> ERP_AccountsService.AccountsService.getAccountBudgetInfoAsync(ERP_AccountsService.getAccountBudgetInfo request)
        {
            return base.Channel.getAccountBudgetInfoAsync(request);
        }
        
        public System.Threading.Tasks.Task<ERP_AccountsService.getAccountBudgetInfoResponse> getAccountBudgetInfoAsync(long accountid)
        {
            ERP_AccountsService.getAccountBudgetInfo inValue = new ERP_AccountsService.getAccountBudgetInfo();
            inValue.accountid = accountid;
            return ((ERP_AccountsService.AccountsService)(this)).getAccountBudgetInfoAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.AccountsServiceImplPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            var _config = FactoryManager.Instance.Resolve<ICoreConfigurations>();
            if ((endpointConfiguration == EndpointConfiguration.AccountsServiceImplPort))
            {
                return new System.ServiceModel.EndpointAddress(_config.ERBAccountsService);
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return AccountsServiceClient.GetBindingForEndpoint(EndpointConfiguration.AccountsServiceImplPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return AccountsServiceClient.GetEndpointAddress(EndpointConfiguration.AccountsServiceImplPort);
        }
        
        public enum EndpointConfiguration
        {
            
            AccountsServiceImplPort,
        }
    }
}
