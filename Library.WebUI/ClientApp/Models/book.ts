export class Book {
    constructor(
        public id: number,
        public year: number,
        public name: string,
        public description: string,
        public authorId: number
    ) { }

}