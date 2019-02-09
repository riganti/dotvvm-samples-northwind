using System;

namespace NorthwindStore.BL.Exceptions
{
    public class RegionAlreadyExistsException : ApplicationException
    {
        
        public RegionAlreadyExistsException() : base("A region with this name already exists!")
        {
        }
        
    }
}