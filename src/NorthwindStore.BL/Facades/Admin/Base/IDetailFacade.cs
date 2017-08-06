namespace NorthwindStore.BL.Facades.Admin.Base
{
    public interface IDetailFacade<TDTO, TKey>
    {
        TDTO GetDetail(TKey id);
        TDTO InitializeNew();
        TDTO Save(TDTO item);
    }
}