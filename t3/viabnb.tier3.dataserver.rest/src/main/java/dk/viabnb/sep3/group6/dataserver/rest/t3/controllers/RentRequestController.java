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
        if (request == null) {
            return ResponseEntity.badRequest().build();
        }
        try {
            RentRequest createdRentRequest = rentRequestDAO.create(request);
            if (createdRentRequest == null) {
                return ResponseEntity.internalServerError().build();
            }
            return ResponseEntity.ok(createdRentRequest);
        } catch (Exception e) {
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
        LOGGER.info("Recived updated request " + new Gson().toJson(request));
        RentRequest updateRequest;
        try
        {
            if (request.getStatus().equals("APPROVED"))
            {
                updateRequest = rentRequestDAO.approveRequest(request);
                return ResponseEntity.ok(updateRequest);
            }
            else if (request.getStatus().equals("NOTAPPROVED"))
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
