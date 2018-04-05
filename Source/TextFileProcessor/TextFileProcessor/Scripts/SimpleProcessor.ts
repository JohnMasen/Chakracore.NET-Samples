//import { CountWords } from "./myLib";//don't use this line, will crash the application
import { CountWords } from "myLib" //the correct style, no leading "./"

interface stringDictionary{
    GetKeys():Array<string>;
    GetItem(key:string):string;
    SetItem(key:string,value:string):void;
    ContainsKey(key:string):boolean;
}
const TOTAL_WORDS="TotalWords";
const AVG_WORDS="AvgWords";
export class App{
    dict:stringDictionary;
    Init(para:stringDictionary){
        this.dict=para;
    }

    Process(row:string):string{
        let words=CountWords;
        this.setSummary(words.length);
        return "Line "+this.getLineNumber()+": Word Count="+words.length.toString();
    }

    getLineNumber(){
        return this.dict.GetItem("Line");
    }

    setSummary(value:number){
        let words=0;
        if (this.dict.ContainsKey(TOTAL_WORDS)) {
            words=Number(this.dict.GetItem(TOTAL_WORDS));
        }
        words+=value;
        this.dict.SetItem(TOTAL_WORDS,words.toString());

        const lines=Number(this.getLineNumber());
        this.dict.SetItem(AVG_WORDS,(words/lines).toString());
    }
}