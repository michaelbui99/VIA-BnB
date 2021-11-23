package dk.viabnb.sep3.group6.dataserver.rest.t3.controllers;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.viabnb.sep3.group6.dataserver.rest.t3.RunDataServer;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.Host.HostDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.dao.residence.ResidenceDAO;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Host;
import dk.viabnb.sep3.group6.dataserver.rest.t3.models.Residence;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController public class HostController
{
  private static final Logger LOGGER = LoggerFactory.getLogger(
      HostController.class);

  // TODO: rename the paths to use /hosts/... as that is the standard for RESTful collections.
  private HostDAO hostDAO;
  private Gson gson = new GsonBuilder().serializeNulls().create();

  @Autowired public HostController(HostDAO hostDAO)
  {
    this.hostDAO = hostDAO;
  }

  @PostMapping("/host") public ResponseEntity<Host> createHost(
      @RequestBody Host host)
  {
    Host newHost = hostDAO.RegisterHost(host);
    if (newHost == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(newHost, HttpStatus.OK);
  }

  @GetMapping("/host/email={email}") public ResponseEntity<Host> getHostByEmail(
      @PathVariable String email)
  {
    Host host;
    host = hostDAO.getHostByEmail(email);
    if (host == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(host, HttpStatus.OK);
  }

  @GetMapping("/host/{id}") public ResponseEntity<Host> getHostById(
      @PathVariable int id)
  {
    Host host;
    host = hostDAO.getHostById(id);
    LOGGER.info("Request for: " + gson.toJson(host));
    return new ResponseEntity<>(host, HttpStatus.OK);
  }

  /**
   * End point of method type GET to get list of Host objects with isApprovedHost boolean value false
   *
   * @return List<Host>
   */
  @GetMapping("/hosts/notApproved") public ResponseEntity<List<Host>> getAllNotApprovedHosts()
  {
    List<Host> hostsToReturn;
    hostsToReturn = hostDAO.getAllNotApprovedHosts();
    if (hostsToReturn == null)
    {
      return ResponseEntity.internalServerError().build();
    }
    return new ResponseEntity<>(hostsToReturn, HttpStatus.OK);
  }

  /**
   * End point of method type PATCH to update isApprovedHost attribute for a given host
   *
   * @param host The targeted Host object
   * @param id   The path variable used to identify the correct host
   * @return A newly updated Host object or ResponseEntity with bad request (depends on the given Host object).
   * or ResponseEntity with not found when catching NoSuchElementException
   */
  @RequestMapping(value = "/hosts/{id}/approval", produces = "application/json", method = RequestMethod.PATCH) public ResponseEntity<Host> updateHostStatus(
      @RequestBody Host host, @PathVariable("id") int id)
  {
    LOGGER.info("Recived updated host from t2: " + new Gson().toJson(host));
    Host updatedHost = null;
    try
    {
      if (host.isApprovedHost())
      {
        updatedHost = hostDAO.approveHost(host);
        return ResponseEntity.ok(updatedHost);
      }
      else if (!host.isApprovedHost())
      {
        updatedHost = hostDAO.rejectHost(host);
        return ResponseEntity.ok(updatedHost);
      }
      return ResponseEntity.badRequest().build();
    }
    catch (NoSuchElementException e)
    {
      e.printStackTrace();
      LOGGER.error("Failed to execute update" + e.getMessage());
      return ResponseEntity.notFound().build();
    }
  }
}
