
package com.baeldung.soap.ws.client.generated;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;
import javax.xml.bind.annotation.XmlSeeAlso;
import javax.xml.ws.RequestWrapper;
import javax.xml.ws.ResponseWrapper;


/**
 * This class was generated by the JAX-WS RI.
 * JAX-WS RI 2.3.2
 * Generated source version: 2.2
 * 
 */
@WebService(name = "IService1", targetNamespace = "http://tempuri.org/")
@XmlSeeAlso({
    ObjectFactory.class
})
public interface IService1 {


    /**
     * 
     * @param origin
     * @param destination
     * @return
     *     returns com.baeldung.soap.ws.client.generated.Itineraire
     */
    @WebMethod(operationName = "GetItineraire", action = "http://tempuri.org/IService1/GetItineraire")
    @WebResult(name = "GetItineraireResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "GetItineraire", targetNamespace = "http://tempuri.org/", className = "com.baeldung.soap.ws.client.generated.GetItineraire")
    @ResponseWrapper(localName = "GetItineraireResponse", targetNamespace = "http://tempuri.org/", className = "com.baeldung.soap.ws.client.generated.GetItineraireResponse")
    public Itineraire getItineraire(
        @WebParam(name = "origin", targetNamespace = "http://tempuri.org/")
        String origin,
        @WebParam(name = "destination", targetNamespace = "http://tempuri.org/")
        String destination);

}
