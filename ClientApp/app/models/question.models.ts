
export interface Question {
    id: number;
    title: string;
    details: string;
    user: {
        firstName: string,
        lastName: string
    };
    createDate: Date;
}

export interface SaveQuestion {
    id: number;
    title: string;
    details: string;
    userid: number;
    questionExtensions: any[];
}