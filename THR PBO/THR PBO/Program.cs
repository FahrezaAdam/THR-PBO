using System;

class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    private static double gajiPokokTetap = 5000000;
    private double bonusTetap = 500000;

    public KaryawanTetap(string nama, string id)
        : base(nama, id, gajiPokokTetap) { }

    public override double HitungGaji()
    {
        return GajiPokok + bonusTetap;
    }
}

class KaryawanKontrak : Karyawan
{
    private static double gajiPokokKontrak = 4000000;
    private double potonganKontrak = 200000;

    public KaryawanKontrak(string nama, string id)
        : base(nama, id, gajiPokokKontrak) { }

    public override double HitungGaji()
    {
        return GajiPokok - potonganKontrak;
    }
}

class KaryawanMagang : Karyawan
{
    private static double gajiPokokMagang = 2000000;

    public KaryawanMagang(string nama, string id)
        : base(nama, id, gajiPokokMagang) { }

    public override double HitungGaji()
    {
        return GajiPokok;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Pilih Jenis Karyawan:");
        Console.WriteLine("1. Tetap");
        Console.WriteLine("2. Kontrak");
        Console.WriteLine("3. Magang");
        Console.Write("Masukkan pilihan (1/2/3): ");
        int pilihan = Convert.ToInt32(Console.ReadLine());

        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID: ");
        string id = Console.ReadLine();

        Karyawan karyawan;

        switch (pilihan)
        {
            case 1:
                karyawan = new KaryawanTetap(nama, id);
                break;
            case 2:
                karyawan = new KaryawanKontrak(nama, id);
                break;
            case 3:
                karyawan = new KaryawanMagang(nama, id);
                break;
            default:
                Console.WriteLine("Pilihan tidak valid.");
                return;
        }

        Console.WriteLine("\n--- Data Karyawan ---");
        Console.WriteLine($"Nama: {karyawan.Nama}");
        Console.WriteLine($"ID: {karyawan.ID}");
        Console.WriteLine($"Gaji Pokok: Rp {karyawan.GajiPokok}");
        Console.WriteLine($"Gaji Akhir: Rp {karyawan.HitungGaji()}");
    }
}