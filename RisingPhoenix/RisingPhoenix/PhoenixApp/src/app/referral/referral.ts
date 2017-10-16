// test
export class Referral {
    constructor(
        public FormID: number,
        public FormType: number, 
        public FormDate: string = "",
        public SenderID: string = "",
        public RecipientID: string = "",
        public ClientID: string = "",
        public SenderMsg: string = ""
    ) { }
}
