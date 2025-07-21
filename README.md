# StaticRustLauncher Backend

Бэкенд для лаунчера игры Rust, предоставляющий API для получения данных о серверах, новостях, хостингах и версиях.

## 🚀 Быстрый старт

### Запуск проекта
```bash
dotnet run
```

### Доступные адреса
- **API**: `http://localhost:5208`
- **Swagger UI**: `http://localhost:5208/swagger`
- **HTTPS**: `https://localhost:7269` (если настроен SSL)

## 📋 API Endpoints

### Новости
- **GET** `/api/news` - Получение списка новостей

### Хостинги
- **GET** `/api/hostings` - Получение списка хостингов

### Серверы
- **GET** `/api/servers` - Получение списка серверов

### Статистика
- **GET** `/api/statistics` - Получение статистики (онлайн пользователей, количество серверов)

### Версии
- **GET** `/api/version` - Получение информации о версиях игры и SFTP настройках
- **GET** `/api/version/client` - Получение текущей версии клиента

## 🧪 Тестирование API

### Через Swagger UI
1. Откройте браузер и перейдите по адресу: `http://localhost:5208/swagger`
2. Выберите нужный эндпоинт
3. Нажмите "Try it out" и затем "Execute"

### Через .http файл
В проекте есть файл `StaticRustLauncherBackend.http` с готовыми запросами для тестирования в VS Code или Rider.

### Через curl
```bash
# Новости
curl http://localhost:5208/api/news

# Серверы
curl http://localhost:5208/api/servers

# Статистика
curl http://localhost:5208/api/statistics

# Версии
curl http://localhost:5208/api/version
```

## 📊 Структура ответов

### Стандартный формат (для списков)
```json
{
  "items": [
    // массив объектов
  ],
  "message": "опциональное сообщение",
  "success": true
}
```

### Статистика
```json
{
  "usersOnline": 1250,
  "serversCount": 15
}
```

### Версии
```json
{
  "currentVersion": "2.1.0",
  "clients": {
    "actual": "2.1.0",
    "333": "1.9.5",
    "12333": "1.8.2"
  },
  "sftp": [
    {
      "host": "sftp.hoster.by",
      "port": 22,
      "user": "user2120",
      "pass": "uT3cB1xE1r"
    }
  ]
}
```

## 🏗️ Структура проекта

```
StaticRustLauncherBackend/
├── Controllers/           # API контроллеры
│   ├── NewsController.cs
│   ├── HostingsController.cs
│   ├── ServersController.cs
│   ├── StatisticsController.cs
│   └── VersionController.cs
├── Models/               # Модели данных
│   ├── Server.cs
│   ├── Hosting.cs
│   ├── NewsItem.cs
│   ├── StatisticsData.cs
│   ├── VersionInfo.cs
│   └── ApiResponse.cs
├── Services/             # Сервисы
│   ├── IMockDataService.cs
│   └── MockDataService.cs
├── Properties/           # Настройки запуска
│   └── launchSettings.json
├── Program.cs           # Точка входа
├── StaticRustLauncherBackend.csproj
├── StaticRustLauncherBackend.sln
└── README.md
```

## 🔧 Настройки

### Логирование
- Логи сохраняются в папку `logs/` с ежедневной ротацией
- Формат: `log-YYYY-MM-DD.txt`
- Уровень: Information и выше

### CORS
Настроен для разрешения запросов с любых источников (для разработки).

### Пакеты NuGet
- `Microsoft.AspNetCore.OpenApi` - для Swagger
- `Serilog.AspNetCore` - для логирования
- `Serilog.Sinks.File` - для записи логов в файл
- `Swashbuckle.AspNetCore` - для документации API

## 📝 Следующие этапы

1. ✅ Базовая структура проекта
2. ✅ Простые GET эндпоинты
3. ✅ Серверы и версии
4. 🔄 Авторизация (базовая)
5. 🔄 Файловый сервер (сложная часть)

## 🐛 Отладка

### Запуск в режиме отладки
```bash
dotnet run --configuration Debug
```

### Просмотр логов
```bash
# В реальном времени
Get-Content logs\log-*.txt -Wait

# Последние 50 строк
Get-Content logs\log-*.txt -Tail 50
```

### Проверка статуса сервера
```bash
# Проверка процесса
Get-Process | Where-Object { $_.ProcessName -like "*StaticRust*" }

# Проверка портов
netstat -ano | findstr :5208
```

## 🔗 Интеграция с клиентом

Для интеграции с клиентским приложением замените URL с:
```
http://194.147.90.218/launcher/
```
на:
```
http://localhost:5208/api/
```

### Примеры замены эндпоинтов:
- `serversinfo` → `servers`
- `hostings` → `hostings`
- `news` → `news`
- `version` → `version`
- `client/version` → `version/client` 