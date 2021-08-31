using LibraryDataAccess.DataEntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDataAccess.Abstract
{
    public interface ILibraryAssets
    {
        LibraryAssets GetLibraryAssetsByBookId(string BookId);
        IEnumerable<LibraryAssets> GetLibraryAssets();
        LibraryAssets AddLibraryAssets(LibraryAssets model);
        LibraryAssets Update(LibraryAssets model);
        LibraryAssets Delete(string BookId);
    }
}
