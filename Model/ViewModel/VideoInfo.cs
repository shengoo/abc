using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ViewModel
{

    //public class Rootobject
    //{
    //    //public Result[] Result { get; set; }
    //    public Datum[] Data { get; set; }
    //}
    //public class Datum
    //{
    //    public string TableName { get; set; }
    //    public string PrimaryKey { get; set; }
    //    public int RecordId { get; set; }
    //    public int ScheduleId { get; set; }
    //    public string Subject { get; set; }
    //    public string Url { get; set; }
    //    public int Size { get; set; }
    //    public string Id { get; set; }
    //    public string PASSWORD { get; set; }
    //    public string RecordStartTime { get; set; }
    //    public string RecordEndTime { get; set; }
    //    public string CreateTime { get; set; }
    //}
    public class VideoInfoObject
    {
        public List<ResultModel> Result { get; set; }
        public List<DataModel> Data { get; set; }
        //  public DataModel Data { get; set; }
    }
    public class ResultModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
    public class DataModel
    {
        public string TableName { get; set; }
        public string PrimaryKey { get; set; }
        public int RecordId { get; set; }
        public int ScheduleId { get; set; }
        public string Subject { get; set; }
        public string Url { get; set; }
        public int Size { get; set; }
        public string Id { get; set; }
        public string PASSWORD { get; set; }
        public string RecordStartTime { get; set; }
        public string RecordEndTime { get; set; }
        public string CreateTime { get; set; }
    }

    public class VideoListModel
    {
        public string RecordStartTime { get; set; }
        public string DataUrl { set; get; }
    }
    public class VideoInfoModel
    {
        public int ScheduleId { set; get; }
        public string RecordStartTime { set; get; }
    }
}
