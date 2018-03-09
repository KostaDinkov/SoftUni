function getSortedTickets(tickets_arr, sortCriteria) {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let sortMethods = {
        destination: function (a, b) {
            if (a.destination > b.destination) {
                return 1;
            }
            else if (a.destination < b.destination) {
                return -1
            }
            return 0;
        },
        price: function(a,b){return a.price - b.price},
        status: function(a,b){
            if (a.status > b.status) {
                return 1;
            }
            else if (a.status < b.status) {
                return -1
            }
            return 0;
        }
    };

    let tickets = [];

    function getTicket(ticket_str) {
        let [dest, price, status] = ticket_str.split('|');
        return new Ticket(dest, Number(price), status)
    }

    for (let ticket_str of tickets_arr) {
        tickets.push(getTicket(ticket_str));
    }
    let ticketsSorted = tickets.sort(sortMethods[sortCriteria]);
    return ticketsSorted;
}

getSortedTickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'price'

);

