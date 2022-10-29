//< section id = "header" >
 
//             < !--Fixed navbar-- >
 
//             < nav class= "navbar navbar-default navbar-fixed-top" >
  
//                  < div class= "container" >
   
//                       < div class= "navbar-header" >
    
//                            < button type = "button" class= "navbar-toggle collapsed" data - toggle = "collapse" data - target = "#navbar" aria - expanded = "false" aria - controls = "navbar" >
                    
//                                                < span class= "sr-only" > Toggle navigation </ span >
                        
//                                                    < span class= "icon-bar" ></ span >
                         
//                                                     < span class= "icon-bar" ></ span >
                          
//                                                      < span class= "icon-bar" ></ span >
                           
//                                                   </ button >
                           
//                                                   < a class= "navbar-brand" href = "/Home/Index" >
                             
//                                                         < img src = "~/Content/Logo/logomuz.jpg" height = "46" >
                                
//                                                        </ a >
                                

//                                                        < h2 style = "margin-top:15px;margin-left:365px;font-weight:bold;color:white" href = "/Admin/Index" > STAJ 1 DÖNEMİNE HOŞGELDİNİZ</h2>
                                       
//                    </div>



//                    <div id = "navbar" class= "navbar-collapse collapse" >
  

//                          < ul class= "nav navbar-nav" >
   

//                               < li class= "" >
    
//                                    < a href = "/Admin/Index" > ANA SAYFA </ a >
         
//                                     </ li >


//                                     @if(User.IsInRole("Admin") || User.IsInRole("Eğitim Elemanı"))
//                            {
//                                < li class= "dropdown-submenu" >
 
//                                     < a href = "/Admin/Index" > ADMİN PANELİ </ a >
      
//                                          < ul class= "dropdown-menu" >
       
//                                               < li >< a href = "/Admin/DosyaYukle" > DOSYA VE BİLDİRİM GÖNDER</a></li>
//                                        <li><a href="/Admin/BasvuruDosyalari">STAJ BAŞVURU DOSYALARI</a></li>
//                                        <li><a href="/Admin/StajDonemiBaslatDurdur">STAJ DÖNEMİNİ BAŞLAT-DURDUR</a></li>
//                                        <li><a href="/Admin/StajBasvuruListesi">BAŞVURUSU ONAYLANANLARIN LİSTESİ</a></li>
//                                        <li><a href="/Admin/BasvurusuTamamlananlarınListesi">BAŞVURUSU TAMAMLANANLARIN LİSTESİ</a></li>
//                                        <li><a href="/Admin/TatilGunleri">RESMİ TATİL GÜNLERİNİ BELİRLE</a></li>
//                                        <li><a href="/Admin/StajyerOgrenciStajaBaslatmaBilgileri">STAJYER ÖĞRENCİ STAJA BAŞLATMA BİLGİLERİ</a></li>
//                                        <li><a href="/Admin/StajyerOgrenciStajDefterleri">STAJ DEFTERLERİ</a></li>
//                                        <li><a href="/Admin/YetkiVer">YETKİ VER</a></li>

//                                    </ul>
//                                </li>
//                            }

//                            @if(User.IsInRole("Kullanici"))
//                            {
//    Staj1DB context = new Staj1DB();
//    string numara = User.Identity.Name;
//    int kullaniciId = context.Kullanici.Where(x => x.Numara == numara).Select(x => x.KullaniciID).FirstOrDefault();
//    var veri = context.Kullanici.Where(x => x.KullaniciID == kullaniciId).Select(x => x.StajDurum.StajDurumID == 1).FirstOrDefault();
//    StajyerOgrenciBaslatma sob = context.StajyerOgrenciBaslatma.Where(x => x.KullaniciID == kullaniciId).FirstOrDefault();
//    StajDefteriTeslim sdt = context.StajDefteriTeslim.Where(x => x.KullaniciID == kullaniciId).FirstOrDefault();

//                                < li class= "dropdown-submenu" >
 
//                                     < a href = "" > KULLANICI PANELİ </ a >
      
//                                          < ul class= "dropdown-menu" >
       
//                                               < li >< a href = "/Kullanici/ProfiliDegistir" > PROFİLİM </ a ></ li >
//                                                  @if(veri == false)
//                                        {
//                                            < li class= "dropdown-toggle" >< a href = "/Kullanici/DosyaYukle" > STAJ BAŞVURUSU YAP</a></li>
//                                        }
//                                        < li class= "dropdown-toggle" >< a href = "/Kullanici/GonderilenBelgelerim" > GERİ GÖNDERİLEN BELGELERİM</a></li>
//                                        <li class= "dropdown-toggle" >< a href = "/Kullanici/BasvuruBelgelerim" > BAŞVURU BELGELERİM </ a ></ li >
//                                               @if(veri == false)
//                                        {
//                                            < li class= "dropdown-toggle" >< a href = "/Kullanici/StajBaslamaFormu" > STAJ BAŞLANGIÇ FORMUNU DOLDUR</a></li>
//                                        }
//                                        < li class= "dropdown-toggle" >< a href = "/Kullanici/StajBaslangicFormum" > STAJ BAŞLANGIÇ FORMUM</a></li>

//                                                @if (veri == true && sob != null)
//{
//    if (sdt != null)
//    {
//                                                < li class= "dropdown-toggle" >< a href = "/StajDefteri/GunlukYaz" > STAJ DEFTERİNİ DOLDUR</a></li>
//                                            }
//                                            @*< li class= "dropdown-toggle" >< a href = "/StajDefteri/GunlukGuncelle" > STAJ DEFTERİMİ DÜZENLE</a></li>*@
//                                            <li class= "dropdown-toggle" >< a href = "/StajDefteri/YapilanIsler" > STAJ DEFTERİM </ a ></ li >
       
//                                                   < li class= "dropdown-toggle" >< a href = "/StajDefteri/StajDefteriniYukle" > STAJ DEFTERİNİ GÖNDER</a></li>
//                                        }
//                                    </ ul >
//                                </ li >
//                            }
//                        </ ul >
//                    </ div >< !--/.nav - collapse-- >
//                </ div >
//            </ nav >
//        </ section >


//        < section id = "title" class= "container-fluid wow fadeInDown" >
   
//               < div class= "container" >
    
//                    < div class= "row" >
     
//                         < div class= "col-xs-4" >
      
//                              < h3 > Bilecik Şeyh Edebali Üniversitesi</h3>

//                    </div>

//                    <div class= "col-xs-4" >

//                        @if(User.IsInRole("Kullanici"))
//                        {

//    Staj1DB context = new Staj1DB();


//    string numara = User.Identity.Name;

//    string stajdurum = context.Kullanici.Where(x => x.Numara == numara).Select(x => x.StajDurum.StajDurumAdi).FirstOrDefault();

//                            @*< h2 style = "font-weight:bold;font-style:italic;color:red" > Staj Durumunuz: @stajdurum </ h2 > *@

//                        }


//                    @*</ div >
//                    < div class= "col-xs-4 text-right breadcrumbs" > *@

//                        @if(User.Identity.IsAuthenticated)
//                        {
//    Staj1DB context = new Staj1DB();


//    string numara = User.Identity.Name;
//    string adi = context.Kullanici.Where(x => x.Numara == numara).Select(x => x.Adi).FirstOrDefault();  //isimden kullanıcının adını alma
//    string soyadi = context.Kullanici.Where(x => x.Numara == numara).Select(x => x.Soyadi).FirstOrDefault();  //isimden kullanıcının soyadını alma


//                            < form method = "post" action = "/Kullanici/CikisYap" >
   
//                                   < a href = "javascript:;" onclick = "document.forms[0].submit();" >< span style = "font-family: 'Segoe Print'; font-size: 14px; font-weight: bold " > Hoş Geldin @adi @soyadi ÇIKIŞ YAP </ span ></ a >
             
//                                         </ form >
//                        }
//                        else
//{
//                            @*< li >< a href = "/Kullanici/GirisYap" >< span style = "font-family:'Segoe Print';font-size:17px;font-weight:bold" > GİRİŞ YAP </ span ></ a ></ li >
           
//                                           < li >/</ li >
           
//                                           < li >< a href = "/Kullanici/UyeOl" >< span style = "font-family:'Segoe Print';font-size:17px;font-weight:bold" > ÜYE OL </ span ></ a ></ li > *@

//                        }

//                    </ div >
//                </ div >
//            </ div >
//        </ section >