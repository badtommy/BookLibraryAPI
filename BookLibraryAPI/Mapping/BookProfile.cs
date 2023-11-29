using AutoMapper;
using BookLibrary.Contracts.DTOs.Books;
using BookLibraryAPI.AppLayer.Books.Commands.CreateBook;
using BookLibraryAPI.AppLayer.Books.Commands.DeleteBook;
using BookLibraryAPI.AppLayer.Books.Commands.UpdateBook;
using BookLibraryAPI.AppLayer.Books.Common;

namespace BookLibraryAPI.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDTO, BookResult>().ForPath(dest => dest.Book.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Book.Title, opt => opt.MapFrom(src => src.Title))
                .ForPath(dest => dest.Book.Author, opt => opt.MapFrom(src => src.Author))
                .ForPath(dest => dest.Book.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ReverseMap();

            CreateMap<CreateBookDTO, CreateBookCommand>().ReverseMap();
            CreateMap<BookDTO, UpdateBookCommand>().ReverseMap();
            CreateMap<DeleteBookDTO, DeleteResult>().ReverseMap();
        }
    }
}
