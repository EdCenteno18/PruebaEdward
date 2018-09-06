import {saludo} from "./components/example";
import {despedida} from "./components/example";
import {loadVacancyTable} from "./components/loadVacancyTable";

(()=>{
    loadVacancyTable();
	saludo();
	despedida();

	if (document.body.classList.contains('home')) {
		// functions here
	}else if (document.body.classList.contains('page2')) {
		// functions here
	}
})();