using Rest_ASP_Net.Model;
using Rest_ASP_Net.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rest_ASP_Net.Repository.Implementations
{


        public class BookRepositoryImplementation : IBookRepository
        {
            private MysqlContext _context;

            public BookRepositoryImplementation(MysqlContext context)
            {
                _context = context;
            }

            public Book Create(Book book)
            {
                try
                {
                    _context.Add(book);
                    _context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
                return book;
            }

            public void Delete(long id)
            {
                var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));
                if (result != null)
                {
                    try
                    {
                        _context.Books.Remove(result);
                        _context.SaveChanges();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            public List<Book> FindAll()
            {
                return (_context.Books.ToList());
            }



            public Book FindById(long id)
            {
                return (_context.Books.SingleOrDefault(p => p.Id.Equals(id)));
            }

            public Book Update(Book book)
            {
                if (!Exists(book.Id)) return null;
                var result = _context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));
                if (result != null)
                {


                    try
                    {
                        _context.Entry(result).CurrentValues.SetValues(book);
                        _context.SaveChanges();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                return book;
            }

            public bool Exists(long id)
            {
                return _context.Books.Any(p => p.Id.Equals(id));
            }
        }
    }

