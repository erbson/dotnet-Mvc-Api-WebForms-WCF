//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClienteWebForms.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IServiceCliente")]
    public interface IServiceCliente {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/BuscaTodosClientes", ReplyAction="http://tempuri.org/IServiceCliente/BuscaTodosClientesResponse")]
        Entity.Cliente[] BuscaTodosClientes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/BuscaTodosClientes", ReplyAction="http://tempuri.org/IServiceCliente/BuscaTodosClientesResponse")]
        System.Threading.Tasks.Task<Entity.Cliente[]> BuscaTodosClientesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/RetornaCliente", ReplyAction="http://tempuri.org/IServiceCliente/RetornaClienteResponse")]
        Entity.Cliente[] RetornaCliente(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/RetornaCliente", ReplyAction="http://tempuri.org/IServiceCliente/RetornaClienteResponse")]
        System.Threading.Tasks.Task<Entity.Cliente[]> RetornaClienteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/InsereCliente", ReplyAction="http://tempuri.org/IServiceCliente/InsereClienteResponse")]
        bool InsereCliente(Entity.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/InsereCliente", ReplyAction="http://tempuri.org/IServiceCliente/InsereClienteResponse")]
        System.Threading.Tasks.Task<bool> InsereClienteAsync(Entity.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/RemoveCliente", ReplyAction="http://tempuri.org/IServiceCliente/RemoveClienteResponse")]
        bool RemoveCliente(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/RemoveCliente", ReplyAction="http://tempuri.org/IServiceCliente/RemoveClienteResponse")]
        System.Threading.Tasks.Task<bool> RemoveClienteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/AtualizaCliente", ReplyAction="http://tempuri.org/IServiceCliente/AtualizaClienteResponse")]
        bool AtualizaCliente(Entity.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/AtualizaCliente", ReplyAction="http://tempuri.org/IServiceCliente/AtualizaClienteResponse")]
        System.Threading.Tasks.Task<bool> AtualizaClienteAsync(Entity.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/ClienteExiste", ReplyAction="http://tempuri.org/IServiceCliente/ClienteExisteResponse")]
        bool ClienteExiste(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCliente/ClienteExiste", ReplyAction="http://tempuri.org/IServiceCliente/ClienteExisteResponse")]
        System.Threading.Tasks.Task<bool> ClienteExisteAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceClienteChannel : ClienteWebForms.ServiceReference1.IServiceCliente, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClienteClient : System.ServiceModel.ClientBase<ClienteWebForms.ServiceReference1.IServiceCliente>, ClienteWebForms.ServiceReference1.IServiceCliente {
        
        public ServiceClienteClient() {
        }
        
        public ServiceClienteClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClienteClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClienteClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClienteClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Entity.Cliente[] BuscaTodosClientes() {
            return base.Channel.BuscaTodosClientes();
        }
        
        public System.Threading.Tasks.Task<Entity.Cliente[]> BuscaTodosClientesAsync() {
            return base.Channel.BuscaTodosClientesAsync();
        }
        
        public Entity.Cliente[] RetornaCliente(int id) {
            return base.Channel.RetornaCliente(id);
        }
        
        public System.Threading.Tasks.Task<Entity.Cliente[]> RetornaClienteAsync(int id) {
            return base.Channel.RetornaClienteAsync(id);
        }
        
        public bool InsereCliente(Entity.Cliente cliente) {
            return base.Channel.InsereCliente(cliente);
        }
        
        public System.Threading.Tasks.Task<bool> InsereClienteAsync(Entity.Cliente cliente) {
            return base.Channel.InsereClienteAsync(cliente);
        }
        
        public bool RemoveCliente(int id) {
            return base.Channel.RemoveCliente(id);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveClienteAsync(int id) {
            return base.Channel.RemoveClienteAsync(id);
        }
        
        public bool AtualizaCliente(Entity.Cliente cliente) {
            return base.Channel.AtualizaCliente(cliente);
        }
        
        public System.Threading.Tasks.Task<bool> AtualizaClienteAsync(Entity.Cliente cliente) {
            return base.Channel.AtualizaClienteAsync(cliente);
        }
        
        public bool ClienteExiste(int id) {
            return base.Channel.ClienteExiste(id);
        }
        
        public System.Threading.Tasks.Task<bool> ClienteExisteAsync(int id) {
            return base.Channel.ClienteExisteAsync(id);
        }
    }
}
