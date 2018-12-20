package FinalProject.Pachinko;

import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.RequestMapping;

@RestController
public class Hello {

    @RequestMapping("/")
    public String index() {
        return "Default!";
    }

    @RequestMapping("/lior")
    public String index1() {
        return "Lior is the king!";
    }

    @RequestMapping("/tal")
    public String index2() {
        return "tal is the king!";
    }

}
