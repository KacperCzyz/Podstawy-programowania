class Seat:
    def __init__(self, row, number):
        self.row = row
        self.number = number
        self.available = True

class Show:
    def __init__(self, title):
        self.title = title
        self.seats = [[Seat(chr(65 + i), j + 1) for j in range(5)] for i in range(5)]

    def display(self):
        print(f"\n{self.title} – Dostępne miejsca:")
        for row in self.seats:
            print(row[0].row, " ".join("O" if seat.available else "X" for seat in row))

    def get_seat(self, row_letter, number):
        return self.seats[ord(row_letter) - 65][number - 1]

class Ticket:
    def __init__(self, customer, seat):
        self.customer = customer
        self.seat = seat

    def save(self):
        with open(f"bilet_{self.customer}.txt", "w") as f:
            f.write(f"Bilet dla {self.customer} – miejsce {self.seat.row}{self.seat.number}\n")

def main():
    show = Show("Teatr: ")
    while True:
        show.display()
        name = input("\nImię (lub 'koniec'): ")
        if name.lower() == 'koniec':
            break

        row = input("Rząd (A-E): ").upper()
        number = int(input("Miejsce (1-5): "))

        seat = show.get_seat(row, number)
        if seat.available:
            seat.available = False
            ticket = Ticket(name, seat)
            ticket.save()
            print("✅ Rezerwacja zakończona.")
        else:
            print("❌ Miejsce zajęte.")

if __name__ == "__main__":
    main()
