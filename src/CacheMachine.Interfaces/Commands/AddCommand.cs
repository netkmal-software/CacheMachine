using System;

namespace CacheMachine.Interfaces.Commands
{
    [Serializable]
    public class AddCommand
    {
        public string Key { get; set; }
        public object Value{ get; set; }
        public DateTime ExpiresAt{ get; set; }
    }
}
