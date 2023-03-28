namespace HTD.DataEntities
{
    public interface IDataEntity
    {
        int Id { get; set; }

        void Update(object obj);
    }
}
