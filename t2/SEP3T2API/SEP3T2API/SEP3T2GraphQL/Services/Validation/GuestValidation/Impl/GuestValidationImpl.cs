﻿using System;
using System.Linq;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.GuestValidation.Impl
{
    public class GuestValidationImpl : IGuestValidation
    {
        public bool IsValidStudentNumber(int studentNumber)
        {
            if (studentNumber > 100000 && studentNumber < 999999)
            {
                return true;
            }
            throw new ArgumentException("Invalid student number");
        }

        public bool IsValidPassword(string password)
        {
            int validConditions = 0;
                        if (password == null)
                        {
                            throw new ArgumentException("invalid password");
                        }
            
                        if (password.Length < 8)
                        {
                            throw new ArgumentException("password must at least be a length of 8 characters");
                        }
            
            
                        foreach (char c in password)
                        {
                            if (password.Any(char.IsLower))
                            {
                                validConditions++;
                                break;
                            }
            
                            throw new ArgumentException("password must contain at least one lowercase letter");
                        }
            
                        foreach (char c in password)
                        {
                            if (password.Any(char.IsUpper))
                            {
                                validConditions++;
                                break;
                            }
            
                            throw new ArgumentException("password must contain at least one uppercase letter");
                        }
                        
                        foreach (char c in password)
                        {
                            if (password.Any(char.IsDigit))
                            {
                                validConditions++;
                                break;
                            }
            
                            throw new ArgumentException("password must contain at least one number");
                        }
            
                        if (validConditions == 3)
                        {
                            return true;
                        }
            
                        throw new ArgumentException("password invalid");
        }

        public bool IsValidGuest(Guest guest)
        {
            if (IsValidStudentNumber(guest.ViaId)  && IsValidPassword(guest.Password))
            {
                return true;
            }

            throw new ArgumentException("Invalid host");
        }
    }
}