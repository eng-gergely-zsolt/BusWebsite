using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusApplication.Controllers
{
    public class MapController : Controller
    {
        private readonly BusDBEntities _dbcontext = new BusDBEntities();
        public ActionResult Index()
        {
            List<Bus> busList = _dbcontext.Buses.ToList();
            ViewBag.BusInfo = busList;
            var temp = (from p in _dbcontext.BusPositions
                        select new
                        {
                            Id = p.Id,
                            BusId = p.BusId,
                            Latitude = p.Latitude,
                            Longitude = p.Longitude,
                            BusName = p.Bus.BusName,
                            Timestamp = p.Timestamp
                        }).ToList();
            var model = new EditBusLineViewModel();
            model.Traces = _dbcontext.BusTraces.OrderBy(C => C.OrderNum).ToList();
            model.Stations = _dbcontext.Stations.ToList();
            model.Lines = _dbcontext.Lines.ToList();
            int maxId;
            if (model.Traces.Count != 0) { 
                maxId = model.Traces.Max(a => a.Id);
            }
            else
            {
                maxId = 1;
            }
            foreach(Bus b in busList)
            {
                int traceNum = model.Traces.Where(a => a.BusId == b.BusId).Count();
                
                if(traceNum == 0)
                {
                    var stations = model.Lines.Where(l => l.LineID == b.BusId).OrderBy(l=>l.StationNr).ToList();
                    if(stations.Count != 0)
                    {
                        //int order = 0;
                        foreach(Line st in stations)
                        {
                            maxId += 1;
                            Station station = model.Stations.Find(s => s.StationID == st.StationID);
                            BusTrace trace = new BusTrace();
                            trace.BusId = b.BusId;
                            trace.Id = maxId;
                            trace.Latitude = station.Latitude;
                            trace.Longitude = station.Longitude;
                            trace.EndPoint = true;
                         //   trace.OrderNum = order;
                         //   order += 1;
                            model.Traces.Add(trace);
                        }
                    }
                }

            }
            int order = 0;
            foreach (BusTrace trace in model.Traces)
            {
                trace.OrderNum = order;
                order += 1;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(EditBusLineViewModel model)//[Bind(Include = "StationID,StationName,Longitude,Latitude")] Station station)
        {
            List<BusTrace> oldTraces = _dbcontext.BusTraces.ToList();
            List<Station> oldStations = _dbcontext.Stations.ToList();
            List<Line> oldLines = _dbcontext.Lines.ToList();
            if(model.Lines != null)
            {

            }
            if (model.Stations != null)
            {
                foreach(var entry in model.Stations)
                {
                    var res = oldStations.Where(x => x.StationID == entry.StationID).FirstOrDefault();
                    if(res != null)
                    {
                        if(entry.Longitude !=0 && entry.Latitude != 0) { 
                            res.StationName = entry.StationName;
                            res.Longitude = entry.Longitude;
                            res.Latitude = entry.Latitude;
                        }
                        else
                        {
                            _dbcontext.Stations.Remove(res);
                        }
                    }
                    else
                    {
                        if (entry.Longitude != 0 && entry.Latitude != 0)
                        {
                            _dbcontext.Stations.Add(entry);
                        }
                            
                    }
                }
            }
            if (model.Traces != null)
            {
                foreach (var entry in model.Traces)
                {
                    var res = oldTraces.Where(x => x.Id == entry.Id).FirstOrDefault();
                    if (res != null)
                    {
                        if (entry.Longitude != 0 && entry.Latitude != 0)
                        {
                            res.OrderNum = entry.OrderNum;
                            res.EndPoint = entry.EndPoint;
                            res.Timestamp = DateTime.Now;
                            res.Longitude = entry.Longitude;
                            res.Latitude = entry.Latitude;
                        }
                        else
                        {
                            _dbcontext.BusTraces.Remove(res);
                        }
                    }
                    else
                    {
                        if (entry.Longitude != 0 && entry.Latitude != 0)
                        {

                            entry.Timestamp = DateTime.Now;
                            _dbcontext.BusTraces.Add(entry);
                        }

                    }
                }
            }
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}