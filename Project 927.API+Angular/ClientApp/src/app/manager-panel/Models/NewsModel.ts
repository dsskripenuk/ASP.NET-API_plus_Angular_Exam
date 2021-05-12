import { v4 as uuidv4 } from 'uuid';

export class NewsModel {
    public id: number;
    public title: string;
    public content: string;
    public image: string;
    public releaseDate: string;

    constructor(title: string = "", content: string = "", releaseDate: string = "", image: string = "") {
        this.id = uuidv4();
        this.title = title;
        this.content = content;
        this.image = image;
        this.releaseDate = releaseDate;
    }

    isValid(): boolean {
        if (
            this.title == "" ||
            this.image == "" ||
            this.content == "" ||
            this.releaseDate == ""
            ) {
            return false;
        } else {
            return true;
        }
    }
}
