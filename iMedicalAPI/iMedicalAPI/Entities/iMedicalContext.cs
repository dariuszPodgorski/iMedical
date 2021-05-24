using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace iMedicalAPI.Models
{
    public partial class iMedicalContext : DbContext
    {
        public iMedicalContext()
        {
        }

        public iMedicalContext(DbContextOptions<iMedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administracja> Administracjas { get; set; }
        public virtual DbSet<Badanie> Badanies { get; set; }
        public virtual DbSet<BadanieRodzaj> BadanieRodzajs { get; set; }
        public virtual DbSet<Cennik> Cenniks { get; set; }
        public virtual DbSet<Etat> Etats { get; set; }
        public virtual DbSet<EtatRodzaj> EtatRodzajs { get; set; }
        public virtual DbSet<Kontrakt> Kontrakts { get; set; }
        public virtual DbSet<KontraktRodzaj> KontraktRodzajs { get; set; }
        public virtual DbSet<Lekarz> Lekarzs { get; set; }
        public virtual DbSet<LekarzSpecjalizacja> LekarzSpecjalizacjas { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<OsobaParamedyczna> OsobaParamedycznas { get; set; }
        public virtual DbSet<Pacjent> Pacjents { get; set; }
        public virtual DbSet<Placowka> Placowkas { get; set; }
        public virtual DbSet<PlacowkaRodzaj> PlacowkaRodzajs { get; set; }
        public virtual DbSet<Pracownik> Pracowniks { get; set; }
        public virtual DbSet<Receptum> Recepta { get; set; }
        public virtual DbSet<RozlczenieEtat> RozlczenieEtats { get; set; }
        public virtual DbSet<RozliczenieSzczegoly> RozliczenieSzczegolies { get; set; }
        public virtual DbSet<Skierowanie> Skierowanies { get; set; }
        public virtual DbSet<Specjalizacja> Specjalizacjas { get; set; }
        public virtual DbSet<StanowiskoRodzaj> StanowiskoRodzajs { get; set; }
        public virtual DbSet<TytulRodzaj> TytulRodzajs { get; set; }
        public virtual DbSet<WizytaRodzaj> WizytaRodzajs { get; set; }
        public virtual DbSet<Wizytum> Wizyta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0DVVGHT\\SQLExpress;Database=iMedical;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Administracja>(entity =>
            {
                entity.HasKey(e => e.IdAdministracja)
                    .HasName("PK_ADMINISTRACJA");

                entity.ToTable("Administracja");

                entity.Property(e => e.IdAdministracja).HasColumnName("ID_Administracja");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Badanie>(entity =>
            {
                entity.HasKey(e => e.IdBadanie)
                    .HasName("PK_BADANIE");

                entity.ToTable("Badanie");

                entity.HasIndex(e => e.IdBadanieRodzaj, "Relationship_24_FK");

                entity.HasIndex(e => e.IdCena, "Relationship_25_FK");

                entity.HasIndex(e => e.IdSkierowanie, "Relationship_26_FK");

                entity.HasIndex(e => e.IdPacjent, "Relationship_27_FK");

                entity.HasIndex(e => e.IdOsobaParamedyczna, "Relationship_28_FK");

                entity.Property(e => e.IdBadanie).HasColumnName("ID_Badanie");

                entity.Property(e => e.DataBadania)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_badania");

                entity.Property(e => e.DataRejestracji)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_rejestracji");

                entity.Property(e => e.IdBadanieRodzaj).HasColumnName("ID_Badanie_rodzaj");

                entity.Property(e => e.IdCena).HasColumnName("ID_Cena");

                entity.Property(e => e.IdOsobaParamedyczna).HasColumnName("Id_Osoba_paramedyczna");

                entity.Property(e => e.IdPacjent).HasColumnName("ID_Pacjent");

                entity.Property(e => e.IdSkierowanie).HasColumnName("ID_Skierowanie");

                entity.HasOne(d => d.IdBadanieRodzajNavigation)
                    .WithMany(p => p.Badanies)
                    .HasForeignKey(d => d.IdBadanieRodzaj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BADANIE_RELATIONS_BADANIE_");

                entity.HasOne(d => d.IdCenaNavigation)
                    .WithMany(p => p.Badanies)
                    .HasForeignKey(d => d.IdCena)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BADANIE_RELATIONS_CENNIK");

                entity.HasOne(d => d.IdOsobaParamedycznaNavigation)
                    .WithMany(p => p.Badanies)
                    .HasForeignKey(d => d.IdOsobaParamedyczna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BADANIE_RELATIONS_OSOBA_PA");

                entity.HasOne(d => d.IdPacjentNavigation)
                    .WithMany(p => p.Badanies)
                    .HasForeignKey(d => d.IdPacjent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BADANIE_RELATIONS_PACJENT");

                entity.HasOne(d => d.IdSkierowanieNavigation)
                    .WithMany(p => p.Badanies)
                    .HasForeignKey(d => d.IdSkierowanie)
                    .HasConstraintName("FK_BADANIE_RELATIONS_SKIEROWA");
            });

            modelBuilder.Entity<BadanieRodzaj>(entity =>
            {
                entity.HasKey(e => e.IdBadanieRodzaj)
                    .HasName("PK_BADANIE_RODZAJ");

                entity.ToTable("Badanie_rodzaj");

                entity.Property(e => e.IdBadanieRodzaj).HasColumnName("ID_Badanie_rodzaj");

                entity.Property(e => e.Nazwa).HasMaxLength(32);
            });

            modelBuilder.Entity<Cennik>(entity =>
            {
                entity.HasKey(e => e.IdCena)
                    .HasName("PK_CENNIK");

                entity.ToTable("Cennik");

                entity.Property(e => e.IdCena).HasColumnName("ID_Cena");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Opis).HasMaxLength(512);
            });

            modelBuilder.Entity<Etat>(entity =>
            {
                entity.HasKey(e => e.IdEtat)
                    .HasName("PK_ETAT");

                entity.ToTable("Etat");

                entity.HasIndex(e => e.IdPracownik, "Relationship_3_FK");

                entity.HasIndex(e => e.IdLekarz, "Relationship_4_FK");

                entity.HasIndex(e => e.IdOsobaParamedyczna, "Relationship_5_FK");

                entity.HasIndex(e => e.IdAdministracja, "Relationship_6_FK");

                entity.HasIndex(e => e.IdStanowiskoRodzaj, "Relationship_7_FK");

                entity.HasIndex(e => e.IdEtatRodzaj, "Relationship_8_FK");

                entity.Property(e => e.IdEtat).HasColumnName("ID_Etat");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IdAdministracja).HasColumnName("ID_Administracja");

                entity.Property(e => e.IdEtatRodzaj).HasColumnName("ID_Etat_rodzaj");

                entity.Property(e => e.IdLekarz).HasColumnName("ID_Lekarz");

                entity.Property(e => e.IdOsobaParamedyczna).HasColumnName("Id_Osoba_paramedyczna");

                entity.Property(e => e.IdPracownik).HasColumnName("ID_Pracownik");

                entity.Property(e => e.IdStanowiskoRodzaj).HasColumnName("ID_Stanowisko_rodzaj");

                entity.Property(e => e.NrTelefonu)
                    .HasMaxLength(12)
                    .HasColumnName("Nr_telefonu");

                entity.HasOne(d => d.IdAdministracjaNavigation)
                    .WithMany(p => p.Etats)
                    .HasForeignKey(d => d.IdAdministracja)
                    .HasConstraintName("FK_ETAT_RELATIONS_ADMINIST");

                entity.HasOne(d => d.IdEtatRodzajNavigation)
                    .WithMany(p => p.Etats)
                    .HasForeignKey(d => d.IdEtatRodzaj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ETAT_RELATIONS_ETAT_ROD");

                entity.HasOne(d => d.IdLekarzNavigation)
                    .WithMany(p => p.Etats)
                    .HasForeignKey(d => d.IdLekarz)
                    .HasConstraintName("FK_ETAT_RELATIONS_LEKARZ");

                entity.HasOne(d => d.IdOsobaParamedycznaNavigation)
                    .WithMany(p => p.Etats)
                    .HasForeignKey(d => d.IdOsobaParamedyczna)
                    .HasConstraintName("FK_ETAT_RELATIONS_OSOBA_PA");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.Etats)
                    .HasForeignKey(d => d.IdPracownik)
                    .HasConstraintName("FK_ETAT_RELATIONS_PRACOWNI");

                entity.HasOne(d => d.IdStanowiskoRodzajNavigation)
                    .WithMany(p => p.Etats)
                    .HasForeignKey(d => d.IdStanowiskoRodzaj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ETAT_RELATIONS_STANOWIS");
            });

            modelBuilder.Entity<EtatRodzaj>(entity =>
            {
                entity.HasKey(e => e.IdEtatRodzaj)
                    .HasName("PK_ETAT_RODZAJ");

                entity.ToTable("Etat_rodzaj");

                entity.Property(e => e.IdEtatRodzaj).HasColumnName("ID_Etat_rodzaj");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Kontrakt>(entity =>
            {
                entity.HasKey(e => e.IdKontrakt)
                    .HasName("PK_KONTRAKT");

                entity.ToTable("Kontrakt");

                entity.HasIndex(e => e.IdKontraktRodzaj, "Relationship_10_FK");

                entity.HasIndex(e => e.IdPlacowka, "Relationship_11_FK");

                entity.HasIndex(e => e.IdEtat, "Relationship_9_FK");

                entity.Property(e => e.IdKontrakt).HasColumnName("ID_Kontrakt");

                entity.Property(e => e.DataZakonczenia)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_zakonczenia");

                entity.Property(e => e.DataZawarcia)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_zawarcia");

                entity.Property(e => e.IdEtat).HasColumnName("ID_Etat");

                entity.Property(e => e.IdKontraktRodzaj).HasColumnName("ID_Kontrakt_rodzaj");

                entity.Property(e => e.IdPlacowka).HasColumnName("ID_Placowka");

                entity.Property(e => e.NrKonta)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("Nr_konta");

                entity.Property(e => e.PlacaPodstawowa).HasColumnName("Placa_podstawowa");

                entity.Property(e => e.StawkaGodzinowa).HasColumnName("Stawka_godzinowa");

                entity.Property(e => e.StawkaRyczaltowa).HasColumnName("Stawka_ryczaltowa");

                entity.Property(e => e.Uwagi).HasMaxLength(256);

                entity.HasOne(d => d.IdEtatNavigation)
                    .WithMany(p => p.Kontrakts)
                    .HasForeignKey(d => d.IdEtat)
                    .HasConstraintName("FK_KONTRAKT_RELATIONS_ETAT");

                entity.HasOne(d => d.IdKontraktRodzajNavigation)
                    .WithMany(p => p.Kontrakts)
                    .HasForeignKey(d => d.IdKontraktRodzaj)
                    .HasConstraintName("FK_KONTRAKT_RELATIONS_KONTRAKT");

                entity.HasOne(d => d.IdPlacowkaNavigation)
                    .WithMany(p => p.Kontrakts)
                    .HasForeignKey(d => d.IdPlacowka)
                    .HasConstraintName("FK_KONTRAKT_RELATIONS_PLACOWKA");
            });

            modelBuilder.Entity<KontraktRodzaj>(entity =>
            {
                entity.HasKey(e => e.IdKontraktRodzaj)
                    .HasName("PK_KONTRAKT_RODZAJ");

                entity.ToTable("Kontrakt_rodzaj");

                entity.Property(e => e.IdKontraktRodzaj).HasColumnName("ID_Kontrakt_rodzaj");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Lekarz>(entity =>
            {
                entity.HasKey(e => e.IdLekarz)
                    .HasName("PK_LEKARZ");

                entity.ToTable("Lekarz");

                entity.HasIndex(e => e.IdTytulRodzaj, "Relationship_12_FK");

                entity.Property(e => e.IdLekarz).HasColumnName("ID_Lekarz");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IdTytulRodzaj).HasColumnName("ID_Tytul_rodzaj");

                entity.Property(e => e.NrDyplomu)
                    .HasMaxLength(32)
                    .HasColumnName("Nr_dyplomu");

                entity.Property(e => e.NrTelefonu)
                    .HasMaxLength(16)
                    .HasColumnName("Nr_telefonu");

                entity.Property(e => e.Pwz)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("PWZ");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.IdTytulRodzajNavigation)
                    .WithMany(p => p.Lekarzs)
                    .HasForeignKey(d => d.IdTytulRodzaj)
                    .HasConstraintName("FK_LEKARZ_RELATIONS_TYTUL_RO");
            });

            modelBuilder.Entity<LekarzSpecjalizacja>(entity =>
            {
                entity.HasKey(e => e.IdLekarzSpecjalizacja)
                    .HasName("PK_LEKARZSPECJALIZACJA");

                entity.ToTable("LekarzSpecjalizacja");

                entity.HasIndex(e => e.IdLekarz, "Relationship_14_FK");

                entity.HasIndex(e => e.IdSpecjalizacja, "Relationship_15_FK");

                entity.Property(e => e.IdLekarzSpecjalizacja).HasColumnName("ID_LekarzSpecjalizacja");

                entity.Property(e => e.DataOtrzymania)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_otrzymania");

                entity.Property(e => e.IdLekarz).HasColumnName("ID_Lekarz");

                entity.Property(e => e.IdSpecjalizacja).HasColumnName("ID_Specjalizacja");

                entity.HasOne(d => d.IdLekarzNavigation)
                    .WithMany(p => p.LekarzSpecjalizacjas)
                    .HasForeignKey(d => d.IdLekarz)
                    .HasConstraintName("FK_LEKARZSP_RELATIONS_LEKARZ");

                entity.HasOne(d => d.IdSpecjalizacjaNavigation)
                    .WithMany(p => p.LekarzSpecjalizacjas)
                    .HasForeignKey(d => d.IdSpecjalizacja)
                    .HasConstraintName("FK_LEKARZSP_RELATIONS_SPECJALI");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.IdLogin)
                    .HasName("PK_LOGIN");

                entity.ToTable("Login");

                entity.HasIndex(e => e.IdPracownik, "Relationship_1_FK");

                entity.HasIndex(e => e.IdPacjent, "Relationship_2_FK");

                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.IdPacjent).HasColumnName("ID_Pacjent");

                entity.Property(e => e.IdPracownik).HasColumnName("ID_Pracownik");

                entity.Property(e => e.Login1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Login");

                entity.HasOne(d => d.IdPacjentNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdPacjent)
                    .HasConstraintName("FK_LOGIN_RELATIONS_PACJENT");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdPracownik)
                    .HasConstraintName("FK_LOGIN_RELATIONS_PRACOWNI");
            });

            modelBuilder.Entity<OsobaParamedyczna>(entity =>
            {
                entity.HasKey(e => e.IdOsobaParamedyczna)
                    .HasName("PK_OSOBA_PARAMEDYCZNA");

                entity.ToTable("Osoba_paramedyczna");

                entity.HasIndex(e => e.IdTytulRodzaj, "Relationship_13_FK");

                entity.HasIndex(e => e.IdSpecjalizacja, "Relationship_16_FK");

                entity.Property(e => e.IdOsobaParamedyczna).HasColumnName("Id_Osoba_paramedyczna");

                entity.Property(e => e.IdSpecjalizacja).HasColumnName("ID_Specjalizacja");

                entity.Property(e => e.IdTytulRodzaj).HasColumnName("ID_Tytul_rodzaj");

                entity.Property(e => e.NrDyplomu)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("Nr_dyplomu");

                entity.Property(e => e.Pwz)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("PWZ");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.IdSpecjalizacjaNavigation)
                    .WithMany(p => p.OsobaParamedycznas)
                    .HasForeignKey(d => d.IdSpecjalizacja)
                    .HasConstraintName("FK_OSOBA_PA_RELATIONS_SPECJALI");

                entity.HasOne(d => d.IdTytulRodzajNavigation)
                    .WithMany(p => p.OsobaParamedycznas)
                    .HasForeignKey(d => d.IdTytulRodzaj)
                    .HasConstraintName("FK_OSOBA_PA_RELATIONS_TYTUL_RO");
            });

            modelBuilder.Entity<Pacjent>(entity =>
            {
                entity.HasKey(e => e.IdPacjent)
                    .HasName("PK_PACJENT");

                entity.ToTable("Pacjent");

                entity.Property(e => e.IdPacjent).HasColumnName("ID_Pacjent");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_urodzenia");

                entity.Property(e => e.DrugieImie)
                    .HasMaxLength(32)
                    .HasColumnName("Drugie_imie");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.KodPocztowyZameldowania)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("Kod_pocztowy_zameldowania");

                entity.Property(e => e.KodPocztowyZamieszkania)
                    .HasMaxLength(6)
                    .HasColumnName("Kod_pocztowy_zamieszkania");

                entity.Property(e => e.KrajZameldowania)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("Kraj_zameldowania");

                entity.Property(e => e.KrajZamieszkania)
                    .HasMaxLength(64)
                    .HasColumnName("Kraj_zamieszkania");

                entity.Property(e => e.MiejscowoscZameldowania)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("Miejscowosc_zameldowania");

                entity.Property(e => e.MiejscowoscZamieszkania)
                    .HasMaxLength(64)
                    .HasColumnName("Miejscowosc_zamieszkania");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.NrBudynkuZameldowania)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("Nr_budynku_zameldowania");

                entity.Property(e => e.NrBudynkuZamieszkania)
                    .HasMaxLength(11)
                    .HasColumnName("Nr_budynku_zamieszkania");

                entity.Property(e => e.NrKontaktowy)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("Nr_kontaktowy");

                entity.Property(e => e.NrLokaluZameldowania)
                    .HasMaxLength(11)
                    .HasColumnName("Nr_lokalu_zameldowania");

                entity.Property(e => e.NrLokaluZamieszkania)
                    .HasMaxLength(11)
                    .HasColumnName("Nr_lokalu_zamieszkania");

                entity.Property(e => e.NrUbezpieczenia)
                    .HasMaxLength(32)
                    .HasColumnName("Nr_ubezpieczenia");

                entity.Property(e => e.Pesel)
                    .HasMaxLength(16)
                    .HasColumnName("PESEL");

                entity.Property(e => e.Plec)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UlicaZameldowania)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("Ulica_zameldowania");

                entity.Property(e => e.UlicaZamieszkania)
                    .HasMaxLength(64)
                    .HasColumnName("Ulica_zamieszkania");
            });

            modelBuilder.Entity<Placowka>(entity =>
            {
                entity.HasKey(e => e.IdPlacowka)
                    .HasName("PK_PLACOWKA");

                entity.ToTable("Placowka");

                entity.HasIndex(e => e.IdPlacowkaRodzaj, "Relationship_36_FK");

                entity.Property(e => e.IdPlacowka).HasColumnName("ID_Placowka");

                entity.Property(e => e.Aktywnosc)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.IdPlacowkaRodzaj).HasColumnName("ID_Placowka_rodzaj");

                entity.Property(e => e.KodPocztowy)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("Kod_pocztowy");

                entity.Property(e => e.Miejscowosc)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.NazwaDluga)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("Nazwa_dluga");

                entity.Property(e => e.NazwaKrotka)
                    .HasMaxLength(32)
                    .HasColumnName("Nazwa_krotka");

                entity.Property(e => e.Nip)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("NIP");

                entity.Property(e => e.NrBudynku)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("Nr_budynku");

                entity.Property(e => e.NrLokalu)
                    .HasMaxLength(12)
                    .HasColumnName("Nr_lokalu");

                entity.Property(e => e.PlacowkaGlownaId).HasColumnName("Placowka_glowna_id");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.IdPlacowkaRodzajNavigation)
                    .WithMany(p => p.Placowkas)
                    .HasForeignKey(d => d.IdPlacowkaRodzaj)
                    .HasConstraintName("FK_PLACOWKA_RELATIONS_PLACOWKA");
            });

            modelBuilder.Entity<PlacowkaRodzaj>(entity =>
            {
                entity.HasKey(e => e.IdPlacowkaRodzaj)
                    .HasName("PK_PLACOWKA_RODZAJ");

                entity.ToTable("Placowka_rodzaj");

                entity.Property(e => e.IdPlacowkaRodzaj).HasColumnName("ID_Placowka_rodzaj");

                entity.Property(e => e.Nazwa).HasMaxLength(64);
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("PK_PRACOWNIK");

                entity.ToTable("Pracownik");

                entity.Property(e => e.IdPracownik).HasColumnName("ID_Pracownik");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_urodzenia");

                entity.Property(e => e.DrugieImie)
                    .HasMaxLength(32)
                    .HasColumnName("Drugie_imie");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.KodPocztowyZameldowania)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("Kod_pocztowy_zameldowania");

                entity.Property(e => e.KrajZameldowania)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("Kraj_zameldowania");

                entity.Property(e => e.MiejscowoscZameldowania)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("Miejscowosc_zameldowania");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.NrBudynkuZameldowania)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("Nr_budynku_zameldowania");

                entity.Property(e => e.NrKontaktowy)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("Nr_kontaktowy");

                entity.Property(e => e.NrLokaluZameldowania)
                    .HasMaxLength(11)
                    .HasColumnName("Nr_lokalu_zameldowania");

                entity.Property(e => e.Pesel)
                    .HasMaxLength(16)
                    .HasColumnName("PESEL");

                entity.Property(e => e.Plec)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UlicaZameldowania)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("Ulica_zameldowania");
            });

            modelBuilder.Entity<Receptum>(entity =>
            {
                entity.HasKey(e => e.IdRecepta)
                    .HasName("PK_RECEPTA");

                entity.Property(e => e.IdRecepta).HasColumnName("ID_Recepta");

                entity.Property(e => e.DataWaznosci)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_waznosci");

                entity.Property(e => e.DataWystawienia)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_wystawienia");

                entity.Property(e => e.Lek1).HasColumnName("Lek_1");

                entity.Property(e => e.Lek2).HasColumnName("Lek_2");

                entity.Property(e => e.Lek3).HasColumnName("Lek_3");

                entity.Property(e => e.Lek4).HasColumnName("Lek_4");

                entity.Property(e => e.Lek5).HasColumnName("Lek_5");

                entity.Property(e => e.Lek6).HasColumnName("Lek_6");

                entity.Property(e => e.Lek7).HasColumnName("Lek_7");

                entity.Property(e => e.NrRecepta)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("Nr_recepta");
            });

            modelBuilder.Entity<RozlczenieEtat>(entity =>
            {
                entity.HasKey(e => e.IdRozliczenia)
                    .HasName("PK_ROZLCZENIE_ETAT");

                entity.ToTable("Rozlczenie_etat");

                entity.HasIndex(e => e.IdPracownik, "Relationship_34_FK");

                entity.HasIndex(e => e.IdEtat, "Relationship_35_FK");

                entity.Property(e => e.IdRozliczenia).HasColumnName("ID_Rozliczenia");

                entity.Property(e => e.DataDo)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_do");

                entity.Property(e => e.DataOd)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_od");

                entity.Property(e => e.DataWprowadzenia)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_wprowadzenia");

                entity.Property(e => e.IdEtat).HasColumnName("ID_Etat");

                entity.Property(e => e.IdPracownik).HasColumnName("ID_Pracownik");

                entity.Property(e => e.IloscGodzin).HasColumnName("Ilosc_godzin");

                entity.Property(e => e.IloscNadgodzin).HasColumnName("Ilosc_nadgodzin");

                entity.Property(e => e.Opis).HasMaxLength(512);

                entity.Property(e => e.Uwagi).HasMaxLength(512);

                entity.Property(e => e.WizytyOdplatne).HasColumnName("Wizyty_odplatne");

                entity.Property(e => e.WizytyRefundowane).HasColumnName("Wizyty_refundowane");

                entity.Property(e => e.ZabiegiDodatkowoPlatne).HasColumnName("Zabiegi_dodatkowo_platne");

                entity.Property(e => e.ZabiegiRefundowane).HasColumnName("Zabiegi_refundowane");

                entity.HasOne(d => d.IdEtatNavigation)
                    .WithMany(p => p.RozlczenieEtats)
                    .HasForeignKey(d => d.IdEtat)
                    .HasConstraintName("FK_ROZLCZEN_RELATIONS_ETAT");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.RozlczenieEtats)
                    .HasForeignKey(d => d.IdPracownik)
                    .HasConstraintName("FK_ROZLCZEN_RELATIONS_PRACOWNI");
            });

            modelBuilder.Entity<RozliczenieSzczegoly>(entity =>
            {
                entity.HasKey(e => e.IdRozliczenieSzczegoly)
                    .HasName("PK_ROZLICZENIE_SZCZEGOLY");

                entity.ToTable("Rozliczenie_szczegoly");

                entity.HasIndex(e => e.IdPracownik, "Relationship_30_FK");

                entity.HasIndex(e => e.IdEtat, "Relationship_31_FK");

                entity.HasIndex(e => e.IdKontrakt, "Relationship_32_FK");

                entity.HasIndex(e => e.IdRozliczenia, "Relationship_33_FK");

                entity.Property(e => e.IdRozliczenieSzczegoly).HasColumnName("ID_Rozliczenie_szczegoly");

                entity.Property(e => e.DataPlatnosci)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_platnosci");

                entity.Property(e => e.DataRealizacjiPlatnosci)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_realizacji_platnosci");

                entity.Property(e => e.IdEtat).HasColumnName("ID_Etat");

                entity.Property(e => e.IdKontrakt).HasColumnName("ID_Kontrakt");

                entity.Property(e => e.IdPracownik).HasColumnName("ID_Pracownik");

                entity.Property(e => e.IdRozliczenia).HasColumnName("ID_Rozliczenia");

                entity.Property(e => e.KwotaSuma).HasColumnName("Kwota_suma");

                entity.Property(e => e.Tytul)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Uwagi)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEtatNavigation)
                    .WithMany(p => p.RozliczenieSzczegolies)
                    .HasForeignKey(d => d.IdEtat)
                    .HasConstraintName("FK_ROZLICZE_RELATIONS_ETAT");

                entity.HasOne(d => d.IdKontraktNavigation)
                    .WithMany(p => p.RozliczenieSzczegolies)
                    .HasForeignKey(d => d.IdKontrakt)
                    .HasConstraintName("FK_ROZLICZE_RELATIONS_KONTRAKT");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.RozliczenieSzczegolies)
                    .HasForeignKey(d => d.IdPracownik)
                    .HasConstraintName("FK_ROZLICZE_RELATIONS_PRACOWNI");

                entity.HasOne(d => d.IdRozliczeniaNavigation)
                    .WithMany(p => p.RozliczenieSzczegolies)
                    .HasForeignKey(d => d.IdRozliczenia)
                    .HasConstraintName("FK_ROZLICZE_RELATIONS_ROZLCZEN");
            });

            modelBuilder.Entity<Skierowanie>(entity =>
            {
                entity.HasKey(e => e.IdSkierowanie)
                    .HasName("PK_SKIEROWANIE");

                entity.ToTable("Skierowanie");

                entity.HasIndex(e => e.IdLekarz, "Relationship_21_FK");

                entity.HasIndex(e => e.IdPacjent, "Relationship_22_FK");

                entity.Property(e => e.IdSkierowanie).HasColumnName("ID_Skierowanie");

                entity.Property(e => e.DataWaznosci).HasColumnName("Data_waznosci");

                entity.Property(e => e.DataWystawienia)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_wystawienia");

                entity.Property(e => e.IdBadanieRodzaj).HasColumnName("ID_Badanie_rodzaj");

                entity.Property(e => e.IdLekarz).HasColumnName("ID_Lekarz");

                entity.Property(e => e.IdPacjent).HasColumnName("ID_Pacjent");

                entity.Property(e => e.NrSkierowania)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("Nr_skierowania");

                entity.HasOne(d => d.IdLekarzNavigation)
                    .WithMany(p => p.Skierowanies)
                    .HasForeignKey(d => d.IdLekarz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SKIEROWA_RELATIONS_LEKARZ");

                entity.HasOne(d => d.IdPacjentNavigation)
                    .WithMany(p => p.Skierowanies)
                    .HasForeignKey(d => d.IdPacjent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SKIEROWA_RELATIONS_PACJENT");
            });

            modelBuilder.Entity<Specjalizacja>(entity =>
            {
                entity.HasKey(e => e.IdSpecjalizacja)
                    .HasName("PK_SPECJALIZACJA");

                entity.ToTable("Specjalizacja");

                entity.Property(e => e.IdSpecjalizacja).HasColumnName("ID_Specjalizacja");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<StanowiskoRodzaj>(entity =>
            {
                entity.HasKey(e => e.IdStanowiskoRodzaj)
                    .HasName("PK_STANOWISKO_RODZAJ");

                entity.ToTable("Stanowisko_rodzaj");

                entity.Property(e => e.IdStanowiskoRodzaj).HasColumnName("ID_Stanowisko_rodzaj");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<TytulRodzaj>(entity =>
            {
                entity.HasKey(e => e.IdTytulRodzaj)
                    .HasName("PK_TYTUL_RODZAJ");

                entity.ToTable("Tytul_rodzaj");

                entity.Property(e => e.IdTytulRodzaj).HasColumnName("ID_Tytul_rodzaj");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<WizytaRodzaj>(entity =>
            {
                entity.HasKey(e => e.IdWizytaRodzaj)
                    .HasName("PK_WIZYTA_RODZAJ");

                entity.ToTable("Wizyta_rodzaj");

                entity.Property(e => e.IdWizytaRodzaj).HasColumnName("ID_Wizyta_rodzaj");

                entity.Property(e => e.Nazwa).HasMaxLength(32);
            });

            modelBuilder.Entity<Wizytum>(entity =>
            {
                entity.HasKey(e => e.IdWizyta)
                    .HasName("PK_WIZYTA");

                entity.HasIndex(e => e.IdLekarz, "Relationship_17_FK");

                entity.HasIndex(e => e.IdPlacowka, "Relationship_18_FK");

                entity.HasIndex(e => e.IdPacjent, "Relationship_19_FK");

                entity.HasIndex(e => e.IdWizytaRodzaj, "Relationship_20_FK");

                entity.HasIndex(e => e.IdCena, "Relationship_23_FK");

                entity.HasIndex(e => e.IdRecepta, "Relationship_29_FK");

                entity.Property(e => e.IdWizyta).HasColumnName("ID_Wizyta");

                entity.Property(e => e.DataRejestracji)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_rejestracji");

                entity.Property(e => e.DataWizyty)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_wizyty");

                entity.Property(e => e.DawkowanieLekow)
                    .HasMaxLength(512)
                    .HasColumnName("Dawkowanie_lekow");

                entity.Property(e => e.IdCena).HasColumnName("ID_Cena");

                entity.Property(e => e.IdLekarz).HasColumnName("ID_Lekarz");

                entity.Property(e => e.IdPacjent).HasColumnName("ID_Pacjent");

                entity.Property(e => e.IdPlacowka).HasColumnName("ID_Placowka");

                entity.Property(e => e.IdRecepta).HasColumnName("ID_Recepta");

                entity.Property(e => e.IdWizytaRodzaj).HasColumnName("ID_Wizyta_rodzaj");

                entity.Property(e => e.Informacje)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.InfromacjaOgolna)
                    .HasMaxLength(512)
                    .HasColumnName("Infromacja_ogolna");

                entity.Property(e => e.PrzeprowadzoneCzynnosci)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("Przeprowadzone_czynnosci");

                entity.Property(e => e.Uwagi).HasMaxLength(512);

                entity.Property(e => e.Zalecenia).HasMaxLength(512);

                entity.HasOne(d => d.IdCenaNavigation)
                    .WithMany(p => p.Wizyta)
                    .HasForeignKey(d => d.IdCena)
                    .HasConstraintName("FK_WIZYTA_RELATIONS_CENNIK");

                entity.HasOne(d => d.IdLekarzNavigation)
                    .WithMany(p => p.Wizyta)
                    .HasForeignKey(d => d.IdLekarz)
                    .HasConstraintName("FK_WIZYTA_RELATIONS_LEKARZ");

                entity.HasOne(d => d.IdPacjentNavigation)
                    .WithMany(p => p.Wizyta)
                    .HasForeignKey(d => d.IdPacjent)
                    .HasConstraintName("FK_WIZYTA_RELATIONS_PACJENT");

                entity.HasOne(d => d.IdPlacowkaNavigation)
                    .WithMany(p => p.Wizyta)
                    .HasForeignKey(d => d.IdPlacowka)
                    .HasConstraintName("FK_WIZYTA_RELATIONS_PLACOWKA");

                entity.HasOne(d => d.IdReceptaNavigation)
                    .WithMany(p => p.Wizyta)
                    .HasForeignKey(d => d.IdRecepta)
                    .HasConstraintName("FK_WIZYTA_RELATIONS_RECEPTA");

                entity.HasOne(d => d.IdWizytaRodzajNavigation)
                    .WithMany(p => p.Wizyta)
                    .HasForeignKey(d => d.IdWizytaRodzaj)
                    .HasConstraintName("FK_WIZYTA_RELATIONS_WIZYTA_R");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
