//import { CountWords } from "./myLib";//don't use this line, will crash the application
import { CountWords } from "myLib"; //the correct style, no leading "./"
const TOTAL_WORDS = "TotalWords";
const AVG_WORDS = "AvgWords";
export class App {
    Init(para) {
        this.dict = para;
    }
    Process(row) {
        let words = CountWords;
        this.setSummary(words.length);
        return "Line " + this.getLineNumber() + ": Word Count=" + words.length.toString();
    }
    getLineNumber() {
        return this.dict.GetItem("Line");
    }
    setSummary(value) {
        let words = 0;
        if (this.dict.ContainsKey(TOTAL_WORDS)) {
            words = Number(this.dict.GetItem(TOTAL_WORDS));
        }
        words += value;
        this.dict.SetItem(TOTAL_WORDS, words.toString());
        const lines = Number(this.getLineNumber());
        this.dict.SetItem(AVG_WORDS, (words / lines).toString());
    }
}
//# sourceMappingURL=SimpleProcessor.js.map