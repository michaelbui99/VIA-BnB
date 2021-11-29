package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.rentrequest.RentRequestDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.RentRequest;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController
public class RentRequestController {
    private RentRequestDAO rentRequestDAO;

    private static final Logger LOGGER = LoggerFactory.getLogger(
        RentRequestController.class);
    private Gson gson = new Gson();
    @Autowired
    public RentRequestController(RentRequestDAO rentRequestDAO) {
        this.rentRequestDAO = rentRequestDAO;
    }

    @PostMapping("/rentrequests")
    public ResponseEntity<RentRequest> createRentRequest(@RequestBody RentRequest request) {
        LOGGER.info("Request for: createRentRequest received with params: " +gson.toJson(request) );
        if (request == null) {
            LOGGER.error("Bad request: request was null");
            return ResponseEntity.badRequest().build();
        }
        try {
            LOGGER.info("Creating rent request...");
            RentRequest createdRentRequest = rentRequestDAO.create(request);
            if (createdRentRequest == null) {
                LOGGER.error("Rent request could not be created...");
                return ResponseEntity.internalServerError().build();
            }
            LOGGER.info("New rent request was created: " + gson.toJson(createdRentRequest));
            return ResponseEntity.ok(createdRentRequest);
        } catch (Exception e) {
            LOGGER.error("Rent request could no be created: " + e.getMessage());
            return ResponseEntity.internalServerError().build();
        }
    }


    @GetMapping("/rentrequests")
    public ResponseEntity<List<RentRequest>> getAllRentRequests(@RequestParam(required = false) Integer residenceId,
                                                                @RequestParam(required = false) Integer hostId,
                                                                @RequestParam(required = false) Integer guestId) {
        //TODO: this endpoint works without the RequestParam. When using the RequestParam the result will be null
        List<RentRequest> requestsToReturn = rentRequestDAO.getAll();
        try
        {
            if (residenceId != null) {
                requestsToReturn.forEach((request) -> {
                    if (request.getResidence().getId() != residenceId) {
                        requestsToReturn.remove(request);
                    }
                });
            }

            if (hostId != null) {
                requestsToReturn.forEach((request) -> {
                    if (request.getResidence().getHost().getId() != hostId) {
                        requestsToReturn.remove(request);
                    }
                });
            }
            if (guestId != null) {
                requestsToReturn.forEach((request) -> {
                    if (request.getGuest().getId() != guestId) {
                        requestsToReturn.remove(request);
                    }
                });
            }
        }
        catch (Exception e)
        {
            LOGGER.error(e.getMessage());
        }
            return ResponseEntity.ok(requestsToReturn);
    }


    @GetMapping("/rentrequests/{id}")
    public ResponseEntity<RentRequest> getRentRequest(@PathVariable int id) {
        RentRequest existingRequest = rentRequestDAO.getById(id);
        if (existingRequest == null) {
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok(existingRequest);
    }

    @PutMapping("/rentrequests/{id}")
    public ResponseEntity<RentRequest> replaceRentRequest(@PathVariable int id, @RequestBody(required = true) RentRequest request) {
        RentRequest existingRentRequest = rentRequestDAO.getById(id);
        if (existingRentRequest == null) {
            return ResponseEntity.notFound().build();
        }

        RentRequest updatedRequest = rentRequestDAO.update(request);
        return ResponseEntity.ok(updatedRequest);
    }

    @PatchMapping("/rentrequests/{id}/approval")
    public ResponseEntity<RentRequest> updateRentRequestStatus(@RequestBody RentRequest request, @PathVariable("id") int id)
    {
        RentRequest updateRequest;
        try
        {
            if (request.getStatus().name().equals("APPROVED"))
            {
                updateRequest = rentRequestDAO.approveRequest(request);
                return ResponseEntity.ok(updateRequest);
            }
            else if (request.getStatus().name().equals("NOTAPPROVED"))
            {
                updateRequest = rentRequestDAO.rejectRequest(request);
                return ResponseEntity.ok(updateRequest);
            }
            return ResponseEntity.badRequest().build();
        }
        catch (NoSuchElementException e)
        {
            e.printStackTrace();
            LOGGER.error(e.getMessage());
            return ResponseEntity.notFound().build();
        }
    }
}
