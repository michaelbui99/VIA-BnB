package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.address.AddressDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Address;
import org.apache.coyote.Response;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class AddressController {
    private AddressDAO addressDAO;
    private final Logger LOGGER = LoggerFactory.getLogger(CityController.class);
    @Autowired
    public AddressController(AddressDAO addressDAO) {
        this.addressDAO = addressDAO;
    }

    @GetMapping("/addresses")
    public ResponseEntity<List<Address>> getAll(){
        try {
            LOGGER.info("GET request received for /addresses");
            return ResponseEntity.ok(addressDAO.getAll());
        } catch (Exception e) {
            e.printStackTrace();
            LOGGER.error(e.getMessage());
            return ResponseEntity.internalServerError().build();
        }
    }
}