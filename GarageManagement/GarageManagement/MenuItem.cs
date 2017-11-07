using System;

namespace GarageManagement
{
    public class MenuItem
    {
        public string option;
        public Action RelatedAction { get; set; }
        public string Description;

        public void ExecuteEntry()
        {
            RelatedAction.Invoke();
        }
    }
}