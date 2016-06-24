namespace TMS.Layer.Creators
{
    public interface ICreator<TCreateEntity>
    {
        void Create(TCreateEntity model);
    }
}
