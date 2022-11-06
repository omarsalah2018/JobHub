using CsvHelper;
using CsvHelper.Configuration;
using JobHub.Application.CQRS.Commands;
using JobHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace JobHub.Infrastructure
{
    public class CSVHelper
    {
        public static List<Candidate> LoadCSVData()
        {
            try
            {
                using var streamReader = File.OpenText("CandidateProfile.csv");
                using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);
                var candidates = csvReader.GetRecords<Candidate>().ToList();
                streamReader.Close();
                return candidates;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool WriteRecord(SaveProfileCommand candidate)
        {
            try
            {
                var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false
                };
                using (var stream = File.Open("CandidateProfile.csv", FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, configPersons))
                {

                    csv.WriteRecord(candidate);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static bool WriteRecoreds(List<Candidate> candidates)
        {
            try
            {
                var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                };
                using (var stream = File.Open("CandidateProfile.csv", FileMode.OpenOrCreate))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, configPersons))
                {

                    csv.WriteRecords(candidates);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static bool UpdateRow(SaveProfileCommand command)
        {
            try
            {
                // Can be used cashing here after reading data from CSV file by any tool like as Redis Cashe
                var candidates = CSVHelper.LoadCSVData();
                var candidate = candidates.Where(i => i.Id == command.Id).SingleOrDefault();
                candidates.Remove(candidate);

                // Can be used any mapper here like as Mapster 
                Candidate newRow = new Candidate()
                {
                    Id = command.Id,
                    CallTimeFrom = command.CallTimeFrom,
                    CallTimeTo = command.CallTimeTo,
                    Comment = command.Comment,
                    Email = command.Email,
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    GitHubProfileURL = command.GitHubProfileURL,
                    LinkedInProfileURL = command.LinkedInProfileURL,
                    PhoneNumber = command.PhoneNumber
                };
                candidates.Add(newRow);

                return WriteRecoreds(candidates);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
