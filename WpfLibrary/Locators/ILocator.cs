using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary.Locators;

public interface ILocator
{
    public Type LocateType(Type boundType);
}
