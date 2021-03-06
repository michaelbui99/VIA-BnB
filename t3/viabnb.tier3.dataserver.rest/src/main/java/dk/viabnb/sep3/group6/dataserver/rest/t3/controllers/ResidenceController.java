package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residencereview.ResidenceReviewDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.ResidenceReview;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController public class ResidenceController
{
  private ResidenceDAO residenceDAO;
  private ResidenceReviewDAO residenceReviewDAO;
  private static final Logger LOGGER = LoggerFactory.getLogger(
      ResidenceController.class);

  @Autowired public ResidenceController(ResidenceDAO residenceDAO,
      ResidenceReviewDAO residenceReviewDAO)
  {
    this.residenceDAO = residenceDAO;
    this.residenceReviewDAO = residenceReviewDAO;
  }

  @GetMapping("/residence/host/{id}") public ResponseEntity<List<Residence>> getAllResidencesByHostId(
      @PathVariable int id)
  {
    List<Residence> residences;
    residences = residenceDAO.getAllResidenceByHostId(id);
    if (residences == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(residences, HttpStatus.OK);
  }

  @GetMapping("/residences/{id}") public ResponseEntity<Residence> getResidenceById(
      @PathVariable int id)
  {
    try
    {
      Residence residence = residenceDAO.getResidenceById(id);
      return ResponseEntity.ok(residence);
    }
    catch (IllegalStateException e)
    {
      return ResponseEntity.internalServerError().build();
    }

  }

  @PostMapping("/residences") public ResponseEntity<Residence> createResidence(
      @RequestBody Residence residence)
  {
    LOGGER.info(
"POST request received for /residences");
    Residence newResidence = residenceDAO.createResidence(residence);
    if (newResidence == null)
    {
      return ResponseEntity.badRequest().build();
    }
    return new ResponseEntity<>(newResidence, HttpStatus.OK);
  }

  @GetMapping("/residences") public ResponseEntity<List<Residence>> getAllResidence()
  {
    try
    {
      LOGGER.info("GET request received for /residences");
      List<Residence> residences = residenceDAO.getAllResidences();
      return ResponseEntity.ok(residences);
    }
    catch (Exception e)
    {
      LOGGER.error("Connection failed " + e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @PutMapping("/residences/{id}") public ResponseEntity<Residence> updateAvailabilityPeriod(
      @RequestBody Residence residence, @PathVariable int id)
  {

    try
    {
      Residence existingResidence = residenceDAO.getResidenceById(id);

      if (existingResidence == null)
      {
        return ResponseEntity.notFound().build();
      }

      residenceDAO.updateAvailabilityPeriod(residence);

    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }

    return null;
  }

  @PostMapping("/residences/{residenceId}/residencereviews") public ResponseEntity<ResidenceReview> createResidenceReview(
      @PathVariable int residenceId,
      @RequestBody ResidenceReview residenceReview)
  {
    LOGGER.info("Request for createReview received");
    if (residenceReview == null || residenceId <= 0)
    {
      return ResponseEntity.badRequest().build();
    }
    try
    {
      Residence residence = residenceDAO.getResidenceById(residenceId);
      ResidenceReview createdReview = residenceReviewDAO.createResidenceReview(
          residence, residenceReview);
      if (createdReview == null)
      {
        LOGGER.error("Could not create new ResidenceReview");
        return ResponseEntity.internalServerError().build();
      }
      return ResponseEntity.ok(createdReview);
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @PutMapping("/residences/{residenceId}/residencereviews") public ResponseEntity<ResidenceReview> updateResidenceReview(
      @PathVariable int residenceId,
      @RequestBody ResidenceReview residenceReview)
  {
    if (residenceReview == null || residenceId <= 0)
    {
      return ResponseEntity.badRequest().build();
    }
    try
    {
      ResidenceReview updatedReview = residenceReviewDAO.updateResidenceReview(
          residenceId, residenceReview);
      return ResponseEntity.ok(updatedReview);
    }
    catch (IllegalStateException e)
    {
      LOGGER.error(e.getMessage());
      return ResponseEntity.internalServerError().build();
    }

  }

  @GetMapping("/residences/{residenceId}/residencereviews") public ResponseEntity<List<ResidenceReview>> getAllResidenceReviewsByResidenceId(
      @PathVariable int residenceId)
  {
    try
    {
      LOGGER.info("Request for all residencereviews received");
      List<ResidenceReview> residencereviews = residenceReviewDAO.getAllResidenceReviewsByResidenceId(
          residenceId);
      return ResponseEntity.ok(residencereviews);
    }
    catch (Exception e)
    {
      LOGGER.error("Connection failed " + e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @PatchMapping("/residences/{residenceId}") public ResponseEntity<Residence> updateResidence(
      @RequestBody Residence residence,
      @PathVariable("residenceId") int residenceId)
  {
    try
    {
      residence = residenceDAO.updateResidence(residence);
      return ResponseEntity.ok(residence);
    }
    catch (Exception e)
    {
      LOGGER.error("Connection failed " + e.getMessage());
      return ResponseEntity.internalServerError().build();
    }
  }

  @DeleteMapping("/residences/{residenceId}") public ResponseEntity<Void> deleteResidence(
      @PathVariable("residenceId") int residenceId)
  {
    try
    {
      residenceDAO.deleteResidence(residenceId);
      return new ResponseEntity<>(HttpStatus.OK);
    }
    catch (Exception e)
    {
      LOGGER.error(e.getMessage());
      return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
    }
  }
}
