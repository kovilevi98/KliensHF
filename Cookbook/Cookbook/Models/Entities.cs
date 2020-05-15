using System;
using System.Collections.Generic;

namespace Cookbook.Models
{
    /// <summary>
    /// classes for the first API call it returns a number of found and all of the iformation about the books in the docs list
    /// </summary>
    public class BookList
    {
        public int Start { get; set; }
        public int Num_found { get; set; }
        public int NumFound { get; set; }
        public List<Doc> Docs { get; set; }
    }

    public class Doc
    {
        public string Title_suggest { get; set; }
        public string[] Edition_key { get; set; }
        public int Cover_i { get; set; }
        public string[] Isbn { get; set; }
        public bool Has_fulltext { get; set; }
        public string[] Id_depósito_legal { get; set; }
        public string[] Text { get; set; }
        public string[] Author_name { get; set; }
        public string[] Contributor { get; set; }
        public string[] Ia_loaded_id { get; set; }
        public string[] Seed { get; set; }
        public string[] Oclc { get; set; }
        public string[] Id_google { get; set; }
        public string[] Ia { get; set; }
        public string[] Author_key { get; set; }
        public Availability Availability { get; set; }
        public string[] Subject { get; set; }
        public string Title { get; set; }
        public string Lending_identifier_s { get; set; }
        public string Ia_collection_s { get; set; }
        public int First_publish_year { get; set; }
        public string Type { get; set; }
        public int Ebook_count_i { get; set; }
        public string[] Publish_place { get; set; }
        public string[] Ia_box_id { get; set; }
        public int Edition_count { get; set; }
        public string Key { get; set; }
        public string[] Id_alibris_id { get; set; }
        public string[] Id_goodreads { get; set; }
        public string[] Author_alternative_name { get; set; }
        public bool Public_scan_b { get; set; }
        public string[] Id_overdrive { get; set; }
        public string[] Publisher { get; set; }
        public string[] Id_amazon { get; set; }
        public string[] Id_paperback_swap { get; set; }
        public string[] Id_canadian_national_library_archive { get; set; }
        public string[] Language { get; set; }
        public string[] Lccn { get; set; }
        public int Last_modified_i { get; set; }
        public string Lending_edition_s { get; set; }
        public string[] Id_librarything { get; set; }
        public string Cover_edition_key { get; set; }
        public string[] Person { get; set; }
        public int[] Publish_year { get; set; }
        public string Printdisabled_s { get; set; }
        public string[] Place { get; set; }
        public string[] Time { get; set; }
        public string[] Publish_date { get; set; }
        public string[] Id_wikidata { get; set; }
    }

    public class Availability
    {
        public string Status { get; set; }
        public string Openlibrary_work { get; set; }
        public string Isbn { get; set; }
        public string Num_waitlist { get; set; }
        public String Last_loan_date { get; set; }
        public string Openlibrary_edition { get; set; }
        public object Oclc { get; set; }
        public string Collection { get; set; }
        public String Last_waitlist_date { get; set; }
        public string Identifier { get; set; }
    }




}

