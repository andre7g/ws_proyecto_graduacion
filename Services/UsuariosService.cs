using ws_proyecto.Helpers;
using ws_proyecto.Entities;
using ws_proyecto.Interfaces;
using ws_proyecto.Models.Auth;
using ws_proyecto.Services.Encrypt;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ws_proyecto.Models.ResponseData;

namespace ws_proyecto.Services
{
    public class UsuariosService : IUsuarios
    {
        private DataContext _context;
        public UsuariosService(DataContext context)
        {
            _context = context;
        }

        public void create(Usuarios _Usuarios)
        {
            bool numero = false;
            decimal codigoUsuario = 0;

            while (!numero)
            {
                codigoUsuario = crearCodigo();
                var usuario = _context.Usuarios.Where(x => x.Codigo == codigoUsuario).FirstOrDefault();
                if (usuario == null)
                {
                    numero = true;
                }
            }
            
            var data = _context.Usuarios
                .Where(x => x.Dpi == _Usuarios.Dpi && x.Dpi != 0).FirstOrDefault();

            if (data != null)
                throw new KeyNotFoundException("El DPI del usuario ya existe en el sistema.");

            try
            {
                _Usuarios.Nombres = _Usuarios.Nombres.ToUpper();
                _Usuarios.Apellidos = _Usuarios.Apellidos.ToUpper();
                _Usuarios.Codigo = codigoUsuario;
                _Usuarios.Pass = EncryptService.GetSHA256(codigoUsuario.ToString());
                _Usuarios.Fecha_Inicio = System.DateTime.Now;
                _context.Usuarios.Add(_Usuarios);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Ocurrio un error al asignar el requisito al Acuerdo Ministerial." + ex.Message);
            }
        }

        public object getAll()
        {
            var data = _context.Usuarios.Select(x => new
            {
                x.Id,
                nombre = x.Nombres +" " + x.Apellidos,
                x.Dpi,
                x.Telefono,
                x.Direccion,
                x.Codigo,
                x.Email,
                Fecha_Nacimiento = x.Fecha_Nacimiento.ToString("dd/MM/yyyy"),
                Fecha_Inicio = x.Fecha_Inicio.ToString("dd/MM/yyyy"),
                x.EstadosId,
                x.Estados.Estado,
                Genero = x.Genero == "M" ? "Hombre" : "Mujer"
                //estado = x.Estados.Estado != null ? x.Estados.Estado : "null" 
            });

            data = data.Where(x => x.EstadosId != 3);
            if (data == null) throw new KeyNotFoundException("Asignaciones no encontradas");

            return data.ToList();
        }

        public object getAll(int EstadoId)
        {
            var data = _context.Usuarios.Select(x => new
            {
                x.Id,
                nombre = x.Nombres + " " + x.Apellidos,
                x.Dpi,
                x.Telefono,
                x.Direccion,
                x.Codigo,
                x.Email,
                Fecha_Nacimiento = x.Fecha_Nacimiento.ToString("dd/MM/yyyy"),
                Fecha_Inicio = x.Fecha_Inicio.ToString("dd/MM/yyyy"),
                x.EstadosId,
                x.Estados.Estado,
                x.Genero,
                peso = _context.HistorialUsuarios.Where( h => h.UsuariosId == x.Id && h.EstadosId == 1 ).Select( s => s.Peso).FirstOrDefault(),
                calorias = _context.HistorialUsuarios.Where( h => h.UsuariosId == x.Id && h.EstadosId == 1 ).Select( s => s.CaloriasConsumir).FirstOrDefault(),
                sumatoria_rating = _context.HistorialUsuarios.Where( h => h.UsuariosId == x.Id).Sum(a => a.Rating),
                cantidad_rating = _context.HistorialUsuarios.Where(h => h.UsuariosId == x.Id).Count()

                //estado = x.Estados.Estado != null ? x.Estados.Estado : "null" 
            });;
            if (EstadoId != 0)
            {
                data = data.Where(x => x.EstadosId == EstadoId);
            }

            if (data.ToList().Count() == 0) throw new KeyNotFoundException("Usuarios no encontrados");
            return data.ToList();
        }

        public object getById(int Id)
        {
            var data = _context.Usuarios
            .Where(x => x.Id == Id).FirstOrDefault();

            if (data == null) throw new KeyNotFoundException("Usuario no encontrado.");

            return data;
        }

        public void update(int id, Usuarios _Usuarios)
        {
            var Validar = _context.Usuarios.Where(x => x.Dpi == _Usuarios.Dpi && x.Dpi != 0 && x.Id != _Usuarios.Id && x.EstadosId == 1).FirstOrDefault();

            if (Validar != null)
                throw new KeyNotFoundException("Ya existe un usuario previamente registrado con el mismo dpi");

            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
                throw new KeyNotFoundException("No se encontró el usuario.");

            usuario.Nombres = _Usuarios.Nombres.ToUpper();
            usuario.Apellidos = _Usuarios.Apellidos.ToUpper();
            usuario.Dpi = _Usuarios.Dpi;
            usuario.Telefono = _Usuarios.Telefono;
            usuario.Direccion = _Usuarios.Direccion;
            usuario.Email = _Usuarios.Email;
            usuario.Fecha_Nacimiento = _Usuarios.Fecha_Nacimiento;
            usuario.EstadosId = _Usuarios.EstadosId;
            usuario.Genero = _Usuarios.Genero;
            try
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException("Ocurrio un error al actualizar el Acuerdo Ministerial. " + ex.Message);
            }
        }
        public decimal crearCodigo()
        {
            decimal codigo = 0;
            Random random = new Random();
            codigo = Convert.ToDecimal(random.Next(10000, 99999));
            return codigo;
        }
        public Response Auth(AutenticarRequest model)
        {
            AutenticarResponse response = new AutenticarResponse();
            Response res = new Response();
            try
            {
                var usuario = _context.Usuarios.Where(x => x.Codigo == model.Codigo && x.EstadosId == 3).FirstOrDefault();
                if (usuario != null)
                {
                    string pass = EncryptService.GetSHA256(model.Pass); 
                    if (usuario.Pass == pass)
                    {
                        //var componente_id = await _context.Usuario_Componente.Where(x => x.Usuarios_Id == usuario.Id && x.Estados_Id == 1).Select(x => x.Componentes_Id).FirstOrDefaultAsync();
                        List<RolesUsuarioList> roles = _context.UsuariosRoles.Where(x => x.UsuariosId == usuario.Id && x.EstadosId == 1).Select(x => new RolesUsuarioList { rol_Id = x.RolesId, rol = x.Roles.Rol }).ToList();

                        response.id = usuario.Id;
                        response.Usuario = usuario.Nombres+" "+usuario.Apellidos;
                        response.Roles = roles;
                        response.Token = GetToken(usuario);

                        res.status = 200;
                        res.message = "Autenticado correctamente.";
                        res.data = response;
                    }
                    else
                    {
                        res.status = 400;
                        res.message = "Contraseña incorrecta.";
                        res.data = null;
                    }
                }
                else
                {
                    res.status = 400;
                    res.message = "Codigo incorrecto.";
                    res.data = null;
                }
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = "Ocurrio un error al actualizar el Acuerdo Ministerial. " + ex.Message;
                res.data = null;
            }
            return res;
        }
        public Response Verificar(int Id)
        {
            AutenticarResponse response = new AutenticarResponse();
            Response res = new Response();
            try
            {

                var usuario = _context.Usuarios.Where(x => x.Id == Id).FirstOrDefault();
                //var componente_id = _context.Usuario_Componente.Where(x => x.Usuarios_Id == usuario.Id && x.Estados_Id == 1).Select(x => x.Componentes_Id).FirstOrDefault();

                List<RolesUsuarioList> roles = _context.UsuariosRoles.Where(x => x.UsuariosId == usuario.Id && x.EstadosId == 1).Select(x => new RolesUsuarioList { rol_Id = x.RolesId, rol = x.Roles.Rol }).ToList();

                if (usuario != null)
                {
                    response.id = usuario.Id;
                    response.Usuario = usuario.Nombres + " " + usuario.Apellidos;
                    response.Roles = roles;
                    response.Token = GetToken(usuario);

                    res.status = 200;
                    res.message = "Verificado correctamente.";
                    res.data = response;

                }
                else
                {
                    res.status = 400;
                    res.message = "Verificación incorrecta.";
                    res.data = null;
                }
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = "Ocurrio un error al actualizar el Acuerdo Ministerial. " + ex.Message;
                res.data = null;
            }
            return res;
        }
        public string GetToken(Usuarios usuarios)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("pryectoGraduación123456789");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,usuarios.Id.ToString()),
                        new Claim(ClaimTypes.UserData,usuarios.Codigo.ToString())
                    }

                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public Response AuthMovil(AutenticarRequest model)
        {
            AutenticarMovilResponse response = new AutenticarMovilResponse();
            Response res = new Response();
            try
            {
                var usuario = _context.Usuarios.Where(x => x.Codigo == model.Codigo && x.EstadosId == 1).FirstOrDefault();
                if (usuario != null)
                {
                    string pass = EncryptService.GetSHA256(model.Pass);
                    if (usuario.Pass == pass)
                    {
                        response.id = usuario.Id;
                        response.Usuario = usuario.Nombres + " " + usuario.Apellidos;
                        response.Token = GetToken(usuario);

                        res.status = 200;
                        res.message = "Autenticado correctamente.";
                        res.data = response;
                    }
                    else
                    {
                        res.status = 400;
                        res.message = "Contraseña incorrecta.";
                        res.data = null;
                    }
                }
                else
                {
                    res.status = 400;
                    res.message = "Codigo incorrecto.";
                    res.data = null;
                }
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = "Ocurrio un error al actualizar el Acuerdo Ministerial. " + ex.Message;
                res.data = null;
            }
            return res;
        }

        public Response VerificarMovil(int Id)
        {
            AutenticarMovilResponse response = new AutenticarMovilResponse();
            Response res = new Response();
            try
            {

                var usuario = _context.Usuarios.Where(x => x.Id == Id && x.EstadosId == 1).FirstOrDefault();

                if (usuario != null)
                {
                    response.id = usuario.Id;
                    response.Usuario = usuario.Nombres + " " + usuario.Apellidos;
                    response.Token = GetToken(usuario);

                    res.status = 200;
                    res.message = "Verificado correctamente.";
                    res.data = response;

                }
                else
                {
                    res.status = 400;
                    res.message = "Verificación incorrecta.";
                    res.data = null;
                }
            }
            catch (Exception ex)
            {
                res.status = 500;
                res.message = "Ocurrio un error al actualizar el Acuerdo Ministerial. " + ex.Message;
                res.data = null;
            }
            return res;
        }
    }
}
