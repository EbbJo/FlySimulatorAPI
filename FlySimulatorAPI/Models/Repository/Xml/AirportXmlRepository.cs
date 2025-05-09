﻿
namespace FlySimulatorAPI.Models.Repository.Xml;

public class AirportXmlRepository : XmlRepository<Airport.Airport> {
    public const string XmlPath = "Files/airports.xml";
    
    private readonly IXmlMediator<XmlAirportList> _listMediator;

    public AirportXmlRepository(IXmlMediator<XmlAirportList> listMediator)
        : base(XmlPath) {
        _listMediator = listMediator;
    }
    
    public override void Add(Airport.Airport airport) {
        UpdateList();

        var list = GetList();
        
        list.Add(airport);
        
        SetList(list);
    }

    public override Airport.Airport? GetById(Guid id) {
        UpdateList();
        
        var list = GetList();
        
        return list.FirstOrDefault(obj => obj.Id == id);
    }

    public override List<Airport.Airport> GetAll() {
        UpdateList();

        return GetList();
    }

    public override void Delete(Guid id) {
        UpdateList();
        
        var list = GetList();
        
        list.RemoveAll(airport => airport.Id == id);
        
        SetList(list);
    }
    
    public override void Update(Guid id, Airport.Airport airport) {
        UpdateList();
        
        var list = GetList();

        var index = list.FindIndex(a => a.Id == id);

        if (index == -1) return;
        
        airport.Id = list[index].Id;
        
        list[index] = airport;
        
        SetList(list);
    }

    public override void SaveChanges() {
        if (XmlList is null) return;
        
        _listMediator.ProduceXml((XmlAirportList)XmlList, XmlPath);
    }

    protected override void UpdateList() {
        XmlList = _listMediator.ReadXml(_xmlPath);
    }
}